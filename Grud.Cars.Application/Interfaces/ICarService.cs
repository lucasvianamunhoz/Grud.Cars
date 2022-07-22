using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grud.Cars.Application.Data.Entities;

namespace Grud.Cars.Application.Interfaces
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        void Remove(Car car);
        void Save(Car car);
    }
}
