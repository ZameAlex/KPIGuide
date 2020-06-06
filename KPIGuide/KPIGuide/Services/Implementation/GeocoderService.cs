using System.Collections.Generic;
using System.Threading.Tasks;
using KPIGuide.Services.Interfaces;
using Xamarin.Forms.Maps;

namespace KPIGuide.Services.Implementation
{
    public class GeocoderService : IGeocoderService
    {
        private Geocoder geocoder;

        public GeocoderService(Geocoder geocoder)
        {
            this.geocoder = geocoder;
        }

        public async Task<IEnumerable<string>> GetAddressByPosition(Position position)
        {
           return await geocoder.GetAddressesForPositionAsync(position);
        }

        public async Task<IEnumerable<Position>> GetPositionByAddress(string address)
        {
            return await geocoder.GetPositionsForAddressAsync(address);
        }
    }
}
