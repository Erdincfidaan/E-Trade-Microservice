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
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerService;
        public CargoCustomerService(ICargoCustomerDal cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        public void TDelete(int id)
        {
            _cargoCustomerService.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            var values = _cargoCustomerService.GetAll();
            return values;
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomerService.GetById(id);
        }

        public void TInsert(CargoCustomer obj)
        {
            _cargoCustomerService.Insert(obj);
        }

        public void TUpdate(CargoCustomer obj)
        {
            _cargoCustomerService.Update(obj);
        }
    }
}
