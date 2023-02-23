using Dealership_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership_Application_.Services
{
    public interface IEditCarService
    {
        public Task<Car> EditCar(string? description, double? price, Guid? idCar);
    }
}
