using Business.Abstract;
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

    public List<Car> GetAll()
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            return _carDal.GetAll();
        }
    }

    public List<Car> GetByBrandId(int id)
    {
        return _carDal.GetAll(p => p.BrandId == id);
    }

    public List<Car> GetByColorId(int id)
    {
        return _carDal.GetAll(p => p.ColorId == id);
    }

    public List<Car> GetByPriceRange(decimal min, decimal max)
    {
        return _carDal.GetAll(p => p.DailyPrice>=min && p.DailyPrice<=max);
    }

    public void Add(Car car)
    {
        if (car.Description.Length>=2 && car.DailyPrice>=0)
        {
            _carDal.Add(car);
            Console.WriteLine("New car ADDED successfully ");
        }
    }

    public List<CarDetailsDto> GetCarDetails()
    {
        return _carDal.GetCarDetails();
    }
}