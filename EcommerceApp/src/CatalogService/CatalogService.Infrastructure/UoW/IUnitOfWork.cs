using CatalogService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetRepository<T>() where T: BaseEntity;
        Task SaveChangesAsync();
        Task RollBackTransaction();
    }
}
