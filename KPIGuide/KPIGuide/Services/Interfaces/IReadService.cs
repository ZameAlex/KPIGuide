using System;
using System.Collections.Generic;
using System.Text;
using KPIGuide.Models;

namespace KPIGuide.Services.Interfaces
{
    public interface IReadService
    {
        IEnumerable<Place> ReadAllPlaces();
    }
}
