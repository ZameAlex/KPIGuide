using System;
using System.Collections.Generic;
using System.Text;

namespace KPIGuide.Services.Interfaces
{
    public interface IPositionCalculatorService
    {
        (double Latitude, double Longtitude)
            GetNewPosition((double Latitude, double Longtitude) position, double angle);
    }
}
