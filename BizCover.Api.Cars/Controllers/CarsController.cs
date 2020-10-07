using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Controllers
{
    public class CarsController : ApiController
    {
        private readonly ICarRepository carRepository;
        private readonly ICarDiscountCalculator carDiscountCalculator;

        public CarsController(ICarRepository carRepository, ICarDiscountCalculator carDiscountCalculator)
        {
            this.carRepository = carRepository;
            this.carDiscountCalculator = carDiscountCalculator;
        }

        //ICarRepository carRepo = new CarRepository();

        //GET: api/Cars
        [Route("api/Cars")]
        [HttpGet]
        public async Task<IEnumerable<Car>> GetAllCars()
        {            
            return await carRepository.GetAllCars();
        }

        //GET: api/Cars/1
        [Route("api/Cars/{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCar(int id)
        {
            var cars = await carRepository.GetAllCars();
            var car = cars.FirstOrDefault(c => c.Id == id);

            if(car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        //POST: api/Cars
        [Route("api/Cars")]
        [HttpPost]
        public async Task<int> AddCar(Car car)
        {
            return await carRepository.Add(car);
        }

        //PUT: api/Cars
        [Route("api/Cars")]
        [HttpPut]
        public async Task UpdateCar(Car updatedCar)
        {
            var cars = await carRepository.GetAllCars();
            var car = cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            UpdateCar(car, updatedCar);
            await carRepository.Update(car);
        }

        //GET: api/Cars/DiscountPrice
        [Route("api/Cars/DiscountPrice")]
        [HttpGet]
        //Add car parameter
        public async Task<decimal> GetDiscountPrice(IEnumerable<Car> cars)
        {
            if (cars == null)
            {
                return 0.00M;
            }

            return await Task.Run(() => carDiscountCalculator.CalculateDiscount(cars));            
        }        

        private void UpdateCar(Car car, Car updatedCar)
        {
            car.Colour = updatedCar.Colour;
            car.CountryManufactured = updatedCar.CountryManufactured;
            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;
            car.Price = updatedCar.Price;
            car.Year = updatedCar.Year;
        }
    }
}
