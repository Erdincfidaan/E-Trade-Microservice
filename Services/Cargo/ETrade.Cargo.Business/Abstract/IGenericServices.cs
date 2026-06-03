using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.Business.Abstract
{
    public interface IGenericServices<T> where T : class
    {
        void TInsert(T obj);
        void TDelete(int id);
        void TUpdate(T obj);
        T TGetById(int id);
        List<T> TGetAll();

    }
}
