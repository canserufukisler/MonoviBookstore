using monovi.bookshop.dal.Repository.IRepository;
using monovi.bookshop.model;
using monovi.bookshop.utility.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace monovi.bookshop.dal.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            Product savedProduct = _db.Products.FirstOrDefault(i => i.Id == product.Id);
            if (savedProduct != null)
            {
                savedProduct.Name = product.Name;
                savedProduct.Author = product.Author;
                savedProduct.ISBN = product.ISBN;
                savedProduct.Description = product.Description;
                savedProduct.ModifiedDate = DateTime.Now;
                savedProduct.ModifiedUserID = AccountHelper.GetDefaultAccountID();
            }
        }
    }
}
