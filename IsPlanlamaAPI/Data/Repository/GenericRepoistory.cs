using IsPlanlamaAPI.Business.Interface;
using IsPlanlamaAPI.Data.Context;

namespace IsPlanlamaAPI.Data.Repository
{
    public class GenericRepoistory<T> : IGenericRepository<T> where T : class
    {
        private readonly ProjeContext _context;

        public GenericRepoistory(ProjeContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity); 
            _context.SaveChanges();

        }

        public List<T> GetAll()
        {
            var result=_context.Set<T>().ToList();  
            return result;
        }

        public T GetById(int id)
        {
           var get=_context.Set<T>().Find( id);
            return get;
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                query = include(query);

            return query.ToList();
        }
    }
}
