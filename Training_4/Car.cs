using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Trainings.Training_4
{
    [Serializable]
    public class Car
    {
        public int carId;
        public decimal price;
        public int quantity;
        public decimal total;

        public Car() {
        }
    }
}
