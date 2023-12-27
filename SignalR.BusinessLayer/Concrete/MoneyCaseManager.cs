using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(Moneycase entity)
        {
           _moneyCaseDal.Add(entity);
        }

        public void TDelete(Moneycase entity)
        {
            _moneyCaseDal.Delete(entity);
        }

        public Moneycase TGetById(int id)
        {
            return _moneyCaseDal.GetById(id);
        }

        public List<Moneycase> TGetListAll()
        {
           return _moneyCaseDal.GetListAll();
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(Moneycase entity)
        {
            _moneyCaseDal.Update(entity);
        }
    }
}
