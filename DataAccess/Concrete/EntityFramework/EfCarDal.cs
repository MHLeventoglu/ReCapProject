using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : ICarDal
{
    public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        }
    }

    public Car Get(Expression<Func<Car, bool>>? filter)
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            return context.Set<Car>().SingleOrDefault(filter);
        }
    }

    public void Add(Car entity)
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            var entityToAdd = context.Entry(entity);
            entityToAdd.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Car entity)
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            var entityToDelete = context.Entry(entity);
            entityToDelete.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public void Update(Car entity)
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            var entityToUpdate = context.Entry(entity);
            entityToUpdate.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}