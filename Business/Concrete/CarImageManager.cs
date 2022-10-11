using Business.Abstract;
using Core.Etilities.Results;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _filehelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _filehelper = fileHelper;
        }
        
        public IResult Add(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            throw new NotImplementedException();
        }

        public IResult update(List<IFormFile> formfile, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Update(List<IFormFile> file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
