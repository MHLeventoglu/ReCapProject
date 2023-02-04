using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfColorDal : IColorDal
{
    public List<Car> GetAll(Expression<Func<Color, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public Color Get(Expression<Func<Color, bool>>? filter)
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