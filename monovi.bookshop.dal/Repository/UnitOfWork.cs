using monovi.bookshop.dal.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace monovi.bookshop.dal.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
        }

        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
