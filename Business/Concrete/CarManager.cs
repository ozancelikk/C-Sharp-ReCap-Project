using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Business.Constants;
using Core.Etilities.Results;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }
        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            //yetkisi var mı
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carid)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.CarId==carid));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //return _carDal.GetAll(c=>c.BrandId==id);
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }

        IDataResult<List<CarDetailDto>> ICarService.GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("get")]
        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c => c.BrandId == car.BrandId).Count;
            if (result>=10)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);
            }
            throw new NotImplementedException();
        }
    }
}
