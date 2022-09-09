using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            //CarAdd();
            ListAllCars();
        }
        private static void ListAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                CarId = 7,
                BrandId = 6,
                ColorId = 1,
                DailyPrice = 600,
                ModelYear = 2020,
                Description = "2020 Black Mercedes-Benz"
            });
            foreach (var car in carManager.GetCarsByBrandId(6))
            {
                Console.WriteLine(car.Description + " Adlı Aracı Başarıyla Eklediniz!");
            }
        }
    }
}
