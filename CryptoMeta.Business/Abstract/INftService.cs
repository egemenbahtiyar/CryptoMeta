using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Abstract
{
    public interface INftService
    {
        Nft GetbyId(int id);
        List<Nft> GetAll();
        void Create(Nft entity);
        void Delete(Nft entity);
        void Update(Nft entity);
    }
}
