using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DataAccesLayer.Abstract
{
    public interface IGenericDal<T> where T:class
    {
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        T GetById(int id);
        List<T> GetAll();
    }
}
