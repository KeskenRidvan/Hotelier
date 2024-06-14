using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;
public class Repository<TEntity> : IRepository<TEntity>
	where TEntity : class
{
	private readonly BaseDbContext _context;
	public Repository(BaseDbContext context)
	{
		_context = context;
	}
	public void Delete(TEntity entity)
	{
		_context.Remove(entity);
		_context.SaveChanges();
	}

	public TEntity GetById(int entityId)
	{
		return _context.Set<TEntity>().Find(entityId);
	}

	public List<TEntity> GetList()
	{
		return _context.Set<TEntity>().ToList();
	}

	public void Insert(TEntity entity)
	{
		_context.Add(entity);
		_context.SaveChanges();
	}

	public void Update(TEntity entity)
	{
		_context.Update(entity);
		_context.SaveChanges();
	}
}
