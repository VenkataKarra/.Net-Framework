using BizCover.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizCover.Api.Cars
{
    public interface ICarDiscountCalculator
    {
        decimal CalculateDiscount(IEnumerable<Car> cars);
    }
}
