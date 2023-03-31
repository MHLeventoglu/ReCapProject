using System.Security.Claims;
using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    public List<OperationClaim> GetClaims(User user);
}