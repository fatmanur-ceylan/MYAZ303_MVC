using System.Security.Principal;
using MVC_Odev.Domain.Common;

namespace MVC_Odev.Domain
{

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
