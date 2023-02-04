using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IEntityRepository<T>
{
    List<Car> GetAll(Expression<Func<T, bool>>? filter = null);
    T Get(Expression<Func<T, bool>>? filter);
    void Add(Car car);
    void Delete(Car car);
    void Update(Car car);
}