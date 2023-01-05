using Microsoft.EntityFrameworkCore;
using MVC_Odev.Domain;
using MVC_Odev.Domain.Common;

namespace MVC_Odev.Repository
{
    public class EFEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity: class, IEntity, new()
    {
        private IUserInfo _userInfo;
        private KullaniciDbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public EFEntityRepositoryBase(IUserInfo userInfo, KullaniciDbContext dbContext)
        {
            _userInfo = userInfo;   
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();

        }

        public void Add(TEntity entity)
        {
            if (entity is IHaveCreationTime cast)
            {
                cast.OlusturulmaTarihi = DateTime.Now;
            }
            if (entity is IHaveCreator cast1)
                cast1.OlusturanKullaniciRef = _userInfo.KullaniciId;
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
                entry = _dbSet.Attach(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            if (entity is IHasModificationTime cast)
            {
                cast.DegistirilmeTarihi = DateTime.Now;
            }

            _dbSet.Update(entity);
        }
    }
}
