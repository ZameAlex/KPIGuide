using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using KPIGuide.Models;
using KPIGuide.Services.Implementation;
using KPIGuide.Services.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Map = Xamarin.Forms.Maps.Map;

namespace KPIGuide.Views
{
    public class MapPage : ContentPage
    {
        private readonly IGeocoderService _geocoderService;
        private readonly PlacesDataStore _dataStore;
        private readonly IPositionCalculatorService _calculatorService;
        private double angle;
        private List<string> addresses;
        public Button start;
        public Button go;
        public Map map;
        private string place;

        public MapPage(IGeocoderService geocoderService, IPositionCalculatorService calculatorService, PlacesDataStore dataStore)
        {
            _geocoderService = geocoderService;
            _dataStore = dataStore;
            _calculatorService = calculatorService;
            addresses = _dataStore.GetAllAddresses().ToList();

            if (!Compass.IsMonitoring)
                Compass.Start(SensorSpeed.UI, true);
            Compass.ReadingChanged += Compass_ReadingChanged;

            Title = "Map";

            Position position = new Position(50.450225, 30.461032);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            map = new Map();
            map.IsShowingUser = true;
            map.HasScrollEnabled = true;
            map.HasZoomEnabled = true;
            map.MoveToRegion(mapSpan);
            start = new Button {Text = "Start"};
            start.IsEnabled = true;
            go = new Button{Text = "Go"};
            go.IsEnabled = false;

            start.Clicked += Start_Clicked;

            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children = { map }
            };
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            var position = await Geolocation.GetLastKnownLocationAsync();

            var placeId = await FindPlace(new Position(position.Latitude, position.Longitude));

            place = placeId;
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var result = e.Reading.HeadingMagneticNorth;
            angle = result;
        }

        private async Task<string> FindPlace(Position currentPosition)
        {
            
            var address = await _geocoderService.GetAddressByPosition(currentPosition);
            while (!addresses.Any(a=>address.Contains(a)))
            {
                var newPosition = _calculatorService.GetNewPosition(currentPosition, angle);
                address = await _geocoderService.GetAddressByPosition(newPosition);
            }

            go.IsEnabled = true;
            return _dataStore.GetPlaceByAddress(address.First()).Name;
        }

       
    }
}
