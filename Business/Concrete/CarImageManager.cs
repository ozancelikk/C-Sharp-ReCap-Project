using Business.Abstract;
using Business.Constants;
using Core.Etilities.Results;
using Core.Utilities.Business;
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
        
        public IResult Add(List<IFormFile> formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExcended(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = _filehelper.Upload(formFile, @"wwwroot\\Uploads\\Images\\");
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageAdded(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id));
        }

        public IResult Delete( CarImage carImage)
        {
            _filehelper.Delete(@"wwwroot\\Uploads||Images\\" + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(List<IFormFile> file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfCarImageAdded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count==0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>>GetDefaultImage(int carID)
        {
            List<CarImage> car = new List<CarImage> { new CarImage { CarId = carID, Date = null, ImagePath = "Default.png" } };
            return new SuccessDataResult<List<CarImage>>(car);
        }
        private IResult CheckIfCarImageLimitExcended(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count>5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }
    }
    
}
