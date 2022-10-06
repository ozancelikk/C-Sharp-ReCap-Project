using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using(TContext contex = new TContext())
            {
                var addedEntity = contex.Entry(entity);//Referensı yakala
                addedEntity.State = EntityState.Added;//eklenecek nesne
                contex.SaveChanges();//şimdi ekle 
            }
        }

        public void Delete(TEntity entity)
        {
            using(TContext context=new TContext())
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala
                deletedEntity.State = EntityState.Deleted;//Silinecek Nesne
                context.SaveChanges();//Şimdi sil
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(TContext context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(TContext context=new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity Entity)
        {
            using(TContext context=new TContext())
            {
                var updateEntity = context.Entry(Entity);//Referansı yakala
                updateEntity.State = EntityState.Modified;//Güncellenecek nesne
                context.SaveChanges();//Şimdi Güncelle
            }
        }
    }
}
