using Dealership_Domain;
using Dealership_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership_Application_.Services.impl
{
    public class CreateCar : ICreateCarService
    {
        private readonly IRepository<Car, Guid> CarRepository;
        public CreateCar(IRepository<Car, Guid> carRepository)
        { 
            CarRepository = carRepository;
        }
        async Task<Car> ICreateCarService.CreateCar(string? name, string? description, string? brand, string? model, string? potencia, Color? color, double? price)
        {

            Car newCar = new Car();
            newCar.Create(name, description, brand, model, potencia, color, price); 
            await CarRepository.InsertAsync(newCar);
            await CarRepository.Save();
            return newCar;
        }
    }
   
}
