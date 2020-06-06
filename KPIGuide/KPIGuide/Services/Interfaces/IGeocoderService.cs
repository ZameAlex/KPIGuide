using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;


namespace KPIGuide.Services.Interfaces
{
    public interface IGeocoderService
    {
        Task<IEnumerable<string>> GetAddressByPosition(Position position);

        Task<IEnumerable<Position>> GetPositionByAddress(string address);
    }
}
