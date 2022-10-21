﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Etilities.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        IResult IUserService.Add(User user)
        {    _userDal.Add(user);
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}