using KPIGuide.Services.Interfaces;
using Xamarin.Forms.Maps;
using static System.Math;

namespace KPIGuide.Services.Implementation
{
    public class PositionCalculatorService : IPositionCalculatorService
    {
        const double _delta = 0.000150;

        public Position GetNewPosition(Position position, double angle)
        {
            var deltaX = Cos((PI / 180) * angle);
            var deltaY = Sin((PI / 180) * angle);
            var result = new Position(position.Latitude + deltaY * _delta, position.Longitude + deltaX * _delta);
            return result;

        }
    }
}

//50.450977, 30.466502
//50.446775, 30.453166