using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.DataAccesLayer.Abstract;
using ETrade.Cargo.EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.Business.Concreate
{
    public class CargoOperationService: ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;
        public CargoOperationService(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
           _cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation obj)
        {
            _cargoOperationDal.Insert(obj);
        }

        public void TUpdate(CargoOperation obj)
        {
            _cargoOperationDal.Update(obj);
        }
    }
}
