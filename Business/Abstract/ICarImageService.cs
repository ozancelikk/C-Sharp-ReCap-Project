using Core.Etilities.Results;
using Core.Utilities.Results;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IResult Add(List<IFormFile> formFile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(List<IFormFile> file, CarImage carImage);
    }
}
