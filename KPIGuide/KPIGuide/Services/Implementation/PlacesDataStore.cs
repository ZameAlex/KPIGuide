using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPIGuide.Models;
using KPIGuide.Services.Interfaces;

namespace KPIGuide.Services.Implementation
{
    public class PlacesDataStore : IDataStore<Place>
    {
        private List<Place> places;
        private readonly IReadService service;

        public PlacesDataStore(IReadService service)
        {
            this.service = service;
            places = new List<Place>();
        }

        private void SetItems()
        {
            var readPlaces = service.ReadAllPlaces();
            foreach(var item in readPlaces)
                places.Add(item);
        }

        public bool AddItem(Place item)
        {
            places.Add(item);
            return true;
        }

        public bool UpdateItem(Place item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(string id)
        {
            places.Remove(GetItem(id));
            return true;
        }

        public Place GetItem(string id)
        {
            return places.FirstOrDefault(item => item.Name == id);
        }

        public IEnumerable<Place> GetItems(bool forceRefresh = false)
        {
            return places.AsReadOnly();
        }

        public IEnumerable<string> GetAllAddresses()
        {
            return places.SelectMany(item => item.Addresses);
        }

        public Place GetPlaceByAddress(string address)
        {
            return places.FirstOrDefault(item => item.Addresses.Contains(address));
        }
    }
}
