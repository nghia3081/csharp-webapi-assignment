using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.IRepositories;
using AutoMapper;

namespace DataAccess.Repositories
{
    public abstract class GenericRepository<TEntity, TBusinessObject> : IGenericRepository<TBusinessObject>
        where TEntity : class
        where TBusinessObject : class
    {
        public readonly EStoreContext context;
        public readonly DbSet<TEntity> Set;
        protected readonly IMapper mapper;
        public GenericRepository(EStoreContext eStoreContext, IMapper mapper)
        {
            context = eStoreContext;
            Set = context.Set<TEntity>();
            this.mapper = mapper;
        }
        public virtual async Task<TBusinessObject> Create(TBusinessObject businessObject, CancellationToken cancellationToken = default)
        {
            TEntity entity = mapper.Map<TBusinessObject, TEntity>(businessObject);
            entity = (await Set.AddAsync(entity, cancellationToken)).Entity;
            await context.SaveChangesAsync(cancellationToken);
            return mapper.Map<TEntity, TBusinessObject>(entity);
        }
        public virtual async Task<TBusinessObject> Update(TBusinessObject businessObject, CancellationToken cancellationToken = default)
        {
            TEntity entity = mapper.Map<TBusinessObject, TEntity>(businessObject);
            entity = Set.Update(entity).Entity;
            await context.SaveChangesAsync(cancellationToken);
            return mapper.Map<TEntity, TBusinessObject>(entity);
        }
        public virtual async Task Delete(CancellationToken cancellationToken = default, params object[] entityKeys)
        {
            TEntity entity = await Set.FindAsync(entityKeys, cancellationToken);
            if (entity == null)
                throw new Exception("Not found");
            Set.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task<TBusinessObject> Find(CancellationToken cancellationToken = default, params object[] entityKeys)
        {
            TEntity? entity = await Set.FindAsync(entityKeys, cancellationToken);
            if (entity == null)
                return null;
            return mapper.Map<TEntity, TBusinessObject>(entity);
        }

        public async Task<IEnumerable<TBusinessObject>> GetAll(string? include = null, CancellationToken cancellationToken = default)
        {
            var data = await Task.Run<IEnumerable<TEntity>>(() =>
            {
                IQueryable<TEntity> set = Set;
                if (include != null) set = set.Include($"{include}");
                return set.AsEnumerable<TEntity>();
            });
            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TBusinessObject>>(data);
        }
    }
}
