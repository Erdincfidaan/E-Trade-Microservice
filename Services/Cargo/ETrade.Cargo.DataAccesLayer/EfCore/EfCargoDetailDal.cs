using ETrade.Cargo.DataAccesLayer.Abstract;
using ETrade.Cargo.DataAccesLayer.Concreate.Context;
using ETrade.Cargo.DataAccesLayer.Repository;
using ETrade.Cargo.EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DataAccesLayer.EfCore
{
    public class EfCargoDetailDal:GenericRepository<CargoDetail>, ICargoDetail
    {
        public EfCargoDetailDal(CargoContext context):base (context)
        {

        }
    }
}
