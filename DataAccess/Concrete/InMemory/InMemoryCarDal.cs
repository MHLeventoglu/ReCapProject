using System.Linq.Expressions;
using System.Net.Http.Headers;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : ICarDal
{
    readonly List<Car> _cars;
    private ICarDal _carDalImplementation;

    public InMemoryCarDal()
    {
        _cars = new List<Car>
        {
            new Car(1, 1, 2, 2004, 675250, "Fiat Egea Comfort"),
            new Car(2, 1, 1, 2018, 785290, "Fiat Megan Sport"),
            new Car(3, 2, 3, 2019, 851270, "Togg Sedan Comfort"),
            new Car(4, 3, 2, 2022, 1655550, "Mercedes AMG Extreme")
        };
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetById(int brandId)
    {
        return _cars.Where(p=>p.BrandId == brandId).ToList();
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Car Get(Expression<Func<Car, bool>>? filter)
    {
        throw new NotImplementedException();
    }

    public Car Get()
    {
        throw new NotImplementedException();
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car carToDelete = _cars.SingleOrDefault(p=>p.Id == car.Id);
        _cars.Remove(carToDelete);
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
        carToUpdate.BrandId = car.BrandId;
        carToUpdate.Description = car.Description;
        carToUpdate.ModelYear = car.ModelYear;
        carToUpdate.DailyPrice = car.DailyPrice;
        carToUpdate.ColorId = car.ColorId;
    }
}