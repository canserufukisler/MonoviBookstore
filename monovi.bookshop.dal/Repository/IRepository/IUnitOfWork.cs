using System;
using System.Collections.Generic;
using System.Text;

namespace monovi.bookshop.dal.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }

        void Save();
    }
}
