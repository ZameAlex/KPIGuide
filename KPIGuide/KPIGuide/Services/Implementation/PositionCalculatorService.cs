using KPIGuide.Services.Interfaces;
using static System.Math;

namespace KPIGuide.Services.Implementation
{
    public class PositionCalculatorService : IPositionCalculatorService
    {
        const double _delta = 0.000150;

        public (double Latitude, double Longtitude) GetNewPosition((double Latitude, double Longtitude) position, double angle)
        {
            var deltaX = Cos((PI / 180) * angle);
            var deltaY = Sin((PI / 180) * angle);
            var result = (Latitude: position.Latitude + deltaY * _delta,
                Longtitude: position.Longtitude + deltaX * _delta);
            return result;

        }
    }
}

//50.450977, 30.466502
//50.446775, 30.453166