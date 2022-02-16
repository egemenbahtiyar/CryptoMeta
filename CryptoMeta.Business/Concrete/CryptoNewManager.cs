using CryptoMeta.Business.Abstract;
using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Concrete
{
    public class CryptoNewManager : ICryptoNewService
    {
        private ICryptoNewDal _cryptoNewDal;
        public CryptoNewManager(ICryptoNewDal cryptoNewDal)
        {
            _cryptoNewDal = cryptoNewDal;
        }
        public void Create(CryptoNew entity)
        {
            _cryptoNewDal.Create(entity);
        }

        public void Delete(CryptoNew entity)
        {
            _cryptoNewDal.Delete(entity);
        }

        public List<CryptoNew> GetAll()
        {
            return _cryptoNewDal.GetAll();
        }

        public CryptoNew GetbyId(int id)
        {
            return _cryptoNewDal.GetbyId(id);
        }

        public void Update(CryptoNew entity)
        {
            _cryptoNewDal.Update(entity);
        }
    }
}
