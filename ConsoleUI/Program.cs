// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
foreach (var item in carManager.GetByPriceRange(600,999).Data)
{
    Console.WriteLine("{0} -> {1}TL/Day",item.Description, item.DailyPrice);
}
//
Console.WriteLine("//////////////////////////");
//
foreach (var item in carManager.GetCarDetails().Data)
{
    Console.WriteLine("{0} // {1} // {2}",item.BrandName,item.Description,item.ColorName);
}


// carManager.Add(new Car(5, 3, 6, 2020, 1250, "Tesla Model Y"  ));