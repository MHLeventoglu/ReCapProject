﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    public IDataResult<List<Car>> GetAll();
    public IDataResult<List<Car>> GetByBrandId(int id);
    public IDataResult<List<Car>> GetByColorId(int id);
    public IDataResult<List<Car>> GetByPriceRange(decimal min, decimal max);
    public IResult Add(Car car);
    public IDataResult<List<CarDetailsDto>> GetCarDetails();
}