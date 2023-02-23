using Dealership_Domain;
using Dealership_Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership_Application_.Services.impl
{
    public class EditCarService : IEditCarService
    {
        private readonly IRepository<Car, Guid> CarRepository;
        public EditCarService(IRepository<Car, Guid> carRepository)
        {
            CarRepository = carRepository;
        }
        public async Task<Car> EditCar(string? description, double? price, Guid? idCar)
        {
            Car? editCar = await CarRepository.GetBytIdAsync(idCar!.Value);
            if(editCar == null) throw new ArgumentNullException(nameof(editCar));
            editCar!.edit(description, price);
            await CarRepository.UpdateAsync(editCar);
            await CarRepository.Save();
            return editCar;

        }
    }
}
