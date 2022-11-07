using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<UserDTO> GetDTOById(int userId);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetById(int userId);
        IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO);
        IResult UpdateEmail(UpdateEmailDTO updateFirstAndLastNameDTO);

        // * * * ONLY TEST PURPOSE * * * 

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserById(int userId);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
