using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Cargo.DataAccesLayer.Abstract;

namespace ETrade.Cargo.Business.Concreate
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly ICargoDetail _cargoDetail;
        public CargoDetailService(ICargoDetail cargoDetail)
        {
            _cargoDetail = cargoDetail;
        }
        public void TDelete(int id)
        {
            _cargoDetail.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetail.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetail.GetById(id);
        }

        public void TInsert(CargoDetail obj)
        {
            _cargoDetail.Insert(obj);
        }

        public void TUpdate(CargoDetail obj)
        {
             _cargoDetail.Update(obj);
        }
    }
}
