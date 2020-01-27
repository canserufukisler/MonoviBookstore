using monovi.bookshop.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace monovi.bookshop.dal.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
