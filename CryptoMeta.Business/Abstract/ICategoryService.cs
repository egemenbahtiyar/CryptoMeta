using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetbyId(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Delete(Category entity);
        void Update(Category entity);
    }
}
