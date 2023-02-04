using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfBrandDal : IBrandDal
{
    public List<Car> GetAll(Expression<Func<Brand, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public Brand Get(Expression<Func<Brand, bool>>? filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Car car)
    {
        throw new NotImplementedException();
    }

    public void Delete(Car car)
    {
        throw new NotImplementedException();
    }

    public void Update(Car car)
    {
        throw new NotImplementedException();
    }
}