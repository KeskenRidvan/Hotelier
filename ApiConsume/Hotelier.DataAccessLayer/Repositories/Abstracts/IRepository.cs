namespace Hotelier.DataAccessLayer.Repositories.Abstracts;
public interface IRepository<TEntity> where TEntity : class
{
	void Insert(TEntity entity);
	void Delete(TEntity entity);
	void Update(TEntity entity);
	List<TEntity> GetList();
	TEntity GetById(int entityId);
}