using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from uoc in context.UserOperationClaims
                             join oc in context.OperationClaims 
                             on uoc.OperationClaimId equals oc.Id 
                             where uoc.UserId == user.UserId
                             select new OperationClaim 
                             { Id = oc.Id, Name = oc.Name };
                return result.ToList();
            }
        }

        public UserDTO GetDTO(Expression<Func<User, bool>> filter)
        {
            using (var context = new RentACarContext())
            {
                var result = from user in context.Users.Where(filter)
                             select new UserDTO { 
                                 UserId = user.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email };
                return result.SingleOrDefault();
            }
        }
    }
}
