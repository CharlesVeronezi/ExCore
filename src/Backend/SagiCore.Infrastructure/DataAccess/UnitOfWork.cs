using SagiCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SagiCore.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SagiCoreDbContext _dbcontext;

        public UnitOfWork(SagiCoreDbContext dbContext) => _dbcontext = dbContext;

        public async Task Commit() => await _dbcontext.SaveChangesAsync();
    }
}
