using Business.Abstract;
using Business.Constrants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<UserDTO> GetDTOById(int userId)
        {
            var result = _userDal.GetDTO(u => u.UserId == userId);

            return new SuccessDataResult<UserDTO>(result, Messages.Geted);
        }

        public IResult UpdateEmail(UpdateEmailDTO updateEmailDTO)
        {
            var rulesResult = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(updateEmailDTO.Email));

            if (!rulesResult.Success) return rulesResult;

            var result = _userDal.Get(u => u.UserId == updateEmailDTO.UserId);

            result.Email = updateEmailDTO.Email;

            _userDal.Update(result);

            return new SuccessResult(Messages.EmailUpdated);
        }

        public IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO)
        {
            var result = _userDal.Get(u => u.UserId == updateFirstAndLastNameDTO.UserId);

            result.FirstName = updateFirstAndLastNameDTO.FirstName;

            result.LastName = updateFirstAndLastNameDTO.LastName;

            _userDal.Update(result);

            return new SuccessResult(Messages.FirstAndLastNameUpdated);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);

            return new SuccessDataResult<User>(result, Messages.Geted);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.UserId == userId);

            return new SuccessDataResult<User>(result, Messages.Geted);
        }


        // * * * ONLY TEST PURPOSE * * * 

        public IResult Add(User user)
        {
            var result = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(user.Email));

            if (!result.Success) return result;

            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        private IResult CheckIfEmailIsAlreadyRegistered(string email)
        {
            var userResult = _userDal.Get(u => u.Email == email);
            if (userResult != null)
            {
                return new ErrorResult(Messages.EmailIsAlreadyRegistered);
            }


            return new SuccessResult();
        }
    }
}
