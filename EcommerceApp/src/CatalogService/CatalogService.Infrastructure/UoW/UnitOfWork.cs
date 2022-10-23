using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CatalogService.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private CatalogContext catalogContext;
        private IDbContextTransaction transaction;
        public UnitOfWork(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
            this.transaction = catalogContext.Database.BeginTransaction();
        }

        private bool disposedValue;
        
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(catalogContext);
        }

        public async Task SaveChangesAsync()
        {
            await catalogContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task RollBackTransaction()
        {
            await transaction.RollbackAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    transaction.Dispose();
                    catalogContext.Dispose();
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                catalogContext = null;
                transaction = null;
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

       
    }
}
