namespace Starter.Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        DbContext _dbContext;

        public DbContext InitDbContext() => _dbContext ?? (_dbContext = new DbContext());

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }

    public interface IDbFactory
    {
        DbContext InitDbContext();
    }
}
