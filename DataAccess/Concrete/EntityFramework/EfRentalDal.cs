using Core.Aspects.Autofac.Caching;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context = new RentACarContext())
            {
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.UserId
                             select new RentalDetailDTO
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 FullName = $"{user.FirstName} {user.LastName}",
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
