using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    IDataResult<List<Color>> GetAll();
    IDataResult<Color> Get(int id);
    IResult Add(Color color);
    IResult Delete(Color color);
}