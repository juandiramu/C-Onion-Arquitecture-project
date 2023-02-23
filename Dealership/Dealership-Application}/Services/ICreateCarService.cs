using Dealership_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership_Application_.Services
{
    public interface ICreateCarService
    {
        public Task<Dealership_Domain.Car> CreateCar(string? name, string? description, string? brand, string? model, string? potencia, Color? color, double? price);
    }
}
