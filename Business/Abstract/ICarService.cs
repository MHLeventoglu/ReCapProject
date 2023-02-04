using Entities.Concrete;

namespace Business.Abstract;

public interface ICarService
{
    public List<Car> GetAll();
    public List<Car> GetByBrandId(int id);
    public List<Car> GetByColorId(int id);
    public List<Car> GetByPriceRange(decimal min, decimal max);
    public void Add(Car car);
}