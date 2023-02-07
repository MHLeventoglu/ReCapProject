using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager:IColorService
{
    private IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public void Color(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }
    public List<Color> GetAll()
    {
        return _colorDal.GetAll();
    }

    public Color Get(int id)
    {
        return _colorDal.Get(b => b.ColorId == id);
    }

    public void Add(Color color)
    {
        if (color.ColorName!.Length >= 2)
        {
            _colorDal.Add(color);
            Console.WriteLine("Color successfully added");
        }
        else
        {
            Console.WriteLine("Color name could Not be shorter than 2 chars");
        }
    }

    public void Delete(Color color)
    {
        if (color.ColorName != null) 
        {
            _colorDal.Delete(color);
            Console.WriteLine("Color successfully deleted");
        }
        else
        {
            Console.WriteLine("Color you tried to delete does not exists");
        }
    }

    public void Update(Color color)
    {
        if (color.ColorName != null) 
        {
            _colorDal.Update(color);
            Console.WriteLine("Color successfully updated");
        }
        else
        {
            Console.WriteLine("Color you tried to update does not exists");
        }
    }
}