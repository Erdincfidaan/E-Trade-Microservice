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
    
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;
        public CargoCompanyService(ICargoCompanyDal cargoCompanyDal) 
        {
            _cargoCompanyDal = cargoCompanyDal;
        }
        public void TDelete(int id)
        {
            _cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }

        public void TInsert(CargoCompany obj)
        {
             _cargoCompanyDal.Insert(obj);
        }

        public void TUpdate(CargoCompany obj)
        {
            _cargoCompanyDal.Update(obj);
        }
    }
}
