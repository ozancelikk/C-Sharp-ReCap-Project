using Core.Etilities.Results;
using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add();
        IResult Update();
        IResult Delete();
        IDataResult<List<Customer>> GetById();
        IDataResult<List<Customer>> GetAll();
    }
}
