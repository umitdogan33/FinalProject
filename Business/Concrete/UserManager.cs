using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [CacheAspect]
        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
       
        [CacheAspect]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("kullanıcı eklendi");
        }
        [CacheRemoveAspect("IUserService.Get")]
        public IResult EditProfil(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HasingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var updatedUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status
            };
            _userDal.Update(updatedUser);
            return new SuccessResult("kullanıcı güncellendi");
        }
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(b => b.Id == id));
        }


        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("kullanıcı silindi");
        }
        public IDataResult<User> GetUserByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
