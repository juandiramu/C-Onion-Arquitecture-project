using Dealership_Application_.Services;
using Dealership_Domain;
using Dealership_Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dealership
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICreateCarService Car;
        private readonly ILogger<CarController> _logger;
        private readonly IRepository<Car, Guid> CarRepository;
        private readonly ICreateCarService CreateCar;
        private readonly IEditCarService EditCarService;
        public CarController(ICreateCarService car, ILogger<CarController> logger, IRepository<Car, Guid> carRepository,
            ICreateCarService createCar, IEditCarService editCarService)
        {
            Car = car;
            _logger = logger;
            CarRepository = carRepository;
            CreateCar = createCar;
            EditCarService = editCarService;
        }

        [HttpPost]
        [Route("createCar")]
        public Task<Car> CreateCarAsync(CreateCarModel? model)
        {
            return CreateCar.CreateCar(model!.Name, model.Description, model.Brand, model.Model, model.Potencia, model.Color, model.Price);
        }

        [HttpPut]
        [Route("editCar")]
        public Task<Car> EditCar(EditCarModel editCar)
        {
            return EditCarService.EditCar(editCar.Description, editCar.Price, editCar.Id);
        }
        [HttpDelete]
        [Route("DeleteCar")]
        public async Task<Car?>? DeleteCar(Car? car)
        {
            return await CarRepository.DeleteAsync(car!);
        }
        [HttpGet]
        [Route("GetCars")]
        public async Task<IEnumerable<Car>?>? GetCarsAsync()
        {
            return await CarRepository.GetAllAsync();
        }
    }
    public class CreateCarModel
    {
       public string? Name { get; set; }
       public string? Description { get; set; }
       public string?Brand { get; set; }
        public string? Model { get; set; }
        public string? Potencia { get; set; }
        public Color? Color { get; set; }
        public double? Price { get; set; }
    }
    public class EditCarModel
    {
        public Guid? Id { get; set; }
        public string? Description { get; set;}
        public double? Price { get; set; }

    }


}
