namespace Starter.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public DbContext StarterDbContext => _dbContext ?? (_dbContext = _dbFactory.InitDbContext());

        public void StartTransaction() => StarterDbContext.Database.BeginTransaction();

        public void CommitTransaction()
        {
            StarterDbContext.SaveChanges();
            StarterDbContext.Database.CurrentTransaction.Commit();
        }

        public void CommitChanges()
        {
            StarterDbContext.SaveChanges();
        }

        public void RollBackTransaction() => StarterDbContext.Database.CurrentTransaction.Rollback();
    }

    public interface IUnitOfWork
    {
        void StartTransaction();

        void CommitTransaction();

        void CommitChanges();

        void RollBackTransaction();
    }
}
