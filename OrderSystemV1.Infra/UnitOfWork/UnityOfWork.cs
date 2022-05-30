using Microsoft.EntityFrameworkCore.Storage;
using OrderSystemV1.Domain.Interfaces;
using OrderSystemV1.Infra.SqlDbContext;

namespace OrderSystemV1.Infra.UnitOfWork
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly SqlContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // _transaction.Rollback();
        }
    }
}
