using CryptoMeta.Business.Abstract;
using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Concrete
{
    public class NftManager : INftService
    {
        private INftDal _nftDal;
        public NftManager(INftDal nftDal)
        {
            _nftDal = nftDal;
        }
        public void Create(Nft entity)
        {
            _nftDal.Create(entity);
        }

        public void Delete(Nft entity)
        {
            _nftDal.Delete(entity);
        }

        public List<Nft> GetAll()
        {
            return _nftDal.GetAll();
        }

        public Nft GetbyId(int id)
        {
            return _nftDal.GetbyId(id);
        }

        public void Update(Nft entity)
        {
            _nftDal.Update(entity);
        }
    }
}
