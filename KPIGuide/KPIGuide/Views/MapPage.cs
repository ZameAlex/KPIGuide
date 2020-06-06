using System;
using System.Collections.Generic;
using System.Text;
using KPIGuide.Models;
using KPIGuide.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace KPIGuide.Views
{
    public class MapPage : ContentPage
    {
        private readonly IGeocoderService _geocoderService;
        private readonly IDataStore<Place> _dataStore;
        private readonly IPositionCalculatorService _calculatorService;

        public MapPage(IGeocoderService geocoderService, IPositionCalculatorService positionCalculator, IDataStore<Place> dataStore, IPositionCalculatorService calculatorService)
        {
            _geocoderService = geocoderService;
            _dataStore = dataStore;
            _calculatorService = calculatorService;

            Title = "Map";

            Position position = new Position(50.450225, 30.461032);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Map map = new Map();
            map.IsShowingUser = true;
            map.MoveToRegion(mapSpan);

            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children = { map }
            };
        }
    }
}
