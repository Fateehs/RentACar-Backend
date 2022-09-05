using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
         ICarDal _carDal;

         public CarManager(ICarDal carDal)
         {
             _carDal = carDal;
         }

         public List<Car> GetAll()
         {
             return _carDal.GetAll();
         }

         public List<Car> GetCarsByBrandId(int brandId)
         {
             return _carDal.GetAll(c => c.BrandId == brandId);
         }

         public List<Car> GetCarsByColorId(int colorId)
         {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

         public void Add(Car car)
         {
             if (car.Description.Length > 2 && car.DailyPrice > 0 )
             {
                 _carDal.Add(car);
             }
             else
             {
                 Console.WriteLine("Arabanın adı 2 harften uzun ve günlük fiyatının 0'dan yüksek olması gerekiyor! ");
             }
         }
    }
}
