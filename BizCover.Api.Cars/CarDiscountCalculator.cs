using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizCover.Repository.Cars;

namespace BizCover.Api.Cars
{
    public class CarDiscountCalculator : ICarDiscountCalculator
    {
        public decimal CalculateDiscount(IEnumerable<Car> cars)
        {
            decimal totalDiscount = 0.00M;

            if (cars == null)
            {
                return totalDiscount;
            }

            decimal costExeedDiscount = 0.00M;
            decimal numberOfCarsDiscount = 0.00M;
            decimal oldCarsDiscount = 0.00M;

            decimal costExeedTotalPrice = 0.00M;
            decimal moreThanTwoCarsTotalPrice = 0.00M;
            decimal oldCarsTotalPrice = 0.00M;

            var isMoreThanTwoCars = cars.Count() > 2;

            foreach (var car in cars)
            {
                if (car.Price > 100000)
                {
                    costExeedTotalPrice = costExeedTotalPrice + car.Price;
                }

                if (isMoreThanTwoCars)
                {
                    moreThanTwoCarsTotalPrice = moreThanTwoCarsTotalPrice + car.Price;
                }

                if (car.Year < 2000)
                {
                    oldCarsTotalPrice = oldCarsTotalPrice + car.Price;
                }
            }

            costExeedDiscount = costExeedTotalPrice * 0.05M;
            numberOfCarsDiscount = moreThanTwoCarsTotalPrice * 0.03M;
            oldCarsDiscount = oldCarsTotalPrice * 0.10M;

            totalDiscount = costExeedDiscount + numberOfCarsDiscount + oldCarsDiscount;
            return totalDiscount;
        }
    }
}