using monovi.bookstore.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace monovi.bookstore.dal.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
