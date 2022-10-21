using Core.Entities.Concrete;
using Core.Etilities.Results;
using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
       IResult Add(User user);
       IResult Update(User user);
       IResult Delete(User user);
       IDataResult<User> GetById(int userId);
       IDataResult<List<User>> GetAll();
       User GetByMail(string email);
       List<OperationClaim> GetClaims(User user);
    }
}
