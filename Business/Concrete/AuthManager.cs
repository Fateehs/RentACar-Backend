using Business.Abstract;
using Business.Constrants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Register(RegisterDTO registerDTO, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result = _userService.Add(user);
            if (!result.Success) return new ErrorDataResult<User>(result.Message);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var userToCheck = _userService.GetByMail(loginDTO.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(loginDTO.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt ))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SucessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            var result = BusinessRules.Run(CheckIfPasswordsMatch(updatePasswordDTO.NewPassword, updatePasswordDTO.NewPasswordAgain));
            if (!result.Success) return result;

            var userResult = _userService.GetById(updatePasswordDTO.UserId);

            var passwordVerificationResult = HashingHelper.VerifyPasswordHash(updatePasswordDTO.Password, userResult.Data.PasswordHash, userResult.Data.PasswordSalt);
            if (!passwordVerificationResult) return new ErrorResult(Messages.PasswordIsIncorrect);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(updatePasswordDTO.NewPassword, out passwordHash, out passwordSalt);

            userResult.Data.PasswordHash = passwordHash;
            userResult.Data.PasswordSalt = passwordSalt;

            var updateResult = _userService.Update(userResult.Data);
            if (!updateResult.Success) return updateResult;

            return new SuccessResult(Messages.PasswordUpdated);
        }

        private IResult CheckIfPasswordsMatch(string newPassword, string newPasswordAgain)
        {
            if (newPassword != newPasswordAgain)
                return new ErrorResult(Messages.PasswordsDoNotMatch);

            return new SuccessResult();
        }
    }
}
