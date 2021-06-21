using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
       
       public  IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        public User GetByMail(string email); 
    }
}
