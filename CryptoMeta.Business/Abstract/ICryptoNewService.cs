using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Abstract
{
    public interface ICryptoNewService
    {
        CryptoNew GetbyId(int id);
        List<CryptoNew> GetAll();
        void Create(CryptoNew entity);
        void Delete(CryptoNew entity);
        void Update(CryptoNew entity);
    }
}
