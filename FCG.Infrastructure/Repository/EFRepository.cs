using FCG.Core.Entity;
using FCG.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase

    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            entity.DataCriacao = DateTime.Now;
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}
