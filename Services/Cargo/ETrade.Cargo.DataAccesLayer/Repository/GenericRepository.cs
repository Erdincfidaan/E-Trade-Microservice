using ETrade.Cargo.DataAccesLayer.Abstract;
using ETrade.Cargo.DataAccesLayer.Concreate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DataAccesLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;
        public GenericRepository(CargoContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();

        }

        public List<T> GetAll()
        {
            var values=_context.Set<T>().ToList();
            return values;
        }

        public T GetById(int id)
        {
            var values = _context.Set<T>().Find(id);
            return values;
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }
    }
}
