using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract;

public interface ICarImageService
{
    public IDataResult<List<CarImage>> GetAll();
    public IDataResult<CarImage> GetById(int id);
    public IDataResult<List<CarImage>> GetByCarId(int carId);
    public IResult Add(IFormFile file,CarImage carImage);
    public IResult Delete(CarImage carImage);
    public IResult Update(IFormFile file,CarImage carImage);
}