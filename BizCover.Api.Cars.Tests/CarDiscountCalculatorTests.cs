using BizCover.Api.Cars.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars.Tests
{
    [TestClass]
    public class CarDiscountCalculatorTests
    {
        private readonly ICarDiscountCalculator carDiscountCalculator;

        public CarDiscountCalculatorTests()
        {
            carDiscountCalculator = new CarDiscountCalculator();
        }

        
        [TestMethod]
        public void Verify_Discounts_For_Old_Cars()
        {
            var cars = new List<Car>
            {
                new Car
                { 
                    Colour = "Mauv",
                    CountryManufactured = "Indonesia",
                    Id = 1, 
                    Make = "Nissan", 
                    Model = "Pathfinder",
                    Price = 6000.0M, 
                    Year = 1995
                },
                new Car
                {
                    Colour = "Mauv",
                    CountryManufactured = "Indonesia",
                    Id = 1,
                    Make = "Nissan",
                    Model = "Pathfinder",
                    Price = 4000.0M,
                    Year = 1991
                },
            };
            decimal expectedDiscount = 1000.0M;

            decimal discountPrice = carDiscountCalculator.CalculateDiscount(cars);

            Assert.AreEqual(expectedDiscount, discountPrice);
        }

    }
}
