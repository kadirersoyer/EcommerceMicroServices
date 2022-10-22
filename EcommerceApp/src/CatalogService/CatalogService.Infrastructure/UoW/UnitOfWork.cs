using CatalogService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private CatalogContext catalogContext;
        public UnitOfWork(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        private bool disposedValue;
        
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(catalogContext);
        }

        public async Task SaveChangesAsync()
        {
            await catalogContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    catalogContext.Dispose();
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                catalogContext = null;
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
