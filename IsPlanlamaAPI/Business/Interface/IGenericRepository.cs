namespace IsPlanlamaAPI.Business.Interface
{
    public interface IGenericRepository <T> where T : class
    {
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
        List<T> GetAll();
        IEnumerable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> include = null);
        T GetById(int id);
    }
}
