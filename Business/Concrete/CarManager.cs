﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal )
    {
        _carDal = carDal;
    }

    public IDataResult<List<Car>> GetAll()
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
    }

    public IDataResult<List<Car>> GetByBrandId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
    }

    public IDataResult<List<Car>> GetByColorId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
    }

    public IDataResult<List<Car>> GetByPriceRange(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice>=min && p.DailyPrice<=max));
    }

    public IResult Add(Car car)
    {
        if (car.Description.Length>=2 && car.DailyPrice>=0)
        {
            _carDal.Add(car);
            return new SuccessResult((Messages.CarAdded + car.Description));
        }

        return new ErrorResult(Messages.InvalidCarName);
    }

    public IDataResult<List<CarDetailsDto>> GetCarDetails()
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.CarsListed);
        }
    }
}