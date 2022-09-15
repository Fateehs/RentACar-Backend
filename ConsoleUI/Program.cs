using System;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarDetailsTest();  
            //AddUser();
            //AddCustomer();
            //AddRental();
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 09, 15), ReturnDate = new DateTime(2022, 10, 15) };
            Rental rental2 = new Rental { Id = 2, CarId = 2, CustomerId = 2, RentDate = new DateTime(2022, 08, 12), ReturnDate = new DateTime(2022, 09, 15) };

            rentalManager.Add(rental1);
            rentalManager.Add(rental2);  
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer { Id = 1, UserId = 1, CompanyName = "Ekermak" };
            Customer customer2 = new Customer { Id = 2, UserId = 2, CompanyName = "Turkcell" };

            customerManager.Add(customer1);
            customerManager.Add(customer2);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User { Id = 1, FirstName = "Fatih", LastName = "Selvi", Email = "fatih@gmail.com", Password = "123456" };
            User user2 = new User { Id = 2, FirstName = "Yiğit", LastName = "Akkuş", Email = "yigit@gmail.com", Password = "789456" };

            userManager.Add(user1);
            userManager.Add(user2);
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Model Adı = " + car.CarName + " Markası : " + car.BrandName + " Rengi : " + car.ColorName + " Günlük Fiyatı : " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
