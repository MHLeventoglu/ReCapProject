// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
foreach (var item in carManager.GetByPriceRange(600,999))
{
    Console.WriteLine("{0} -> {1}TL/Day",item.Description, item.DailyPrice);
}

// carManager.Add(new Car(5, 3, 6, 2020, 1250, "Tesla Model Y"  ));