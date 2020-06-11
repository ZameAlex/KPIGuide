using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace KPIGuide.Services.Interfaces
{
    public interface IPositionCalculatorService
    {
        Position GetNewPosition(Position position, double angle);
    }
}
