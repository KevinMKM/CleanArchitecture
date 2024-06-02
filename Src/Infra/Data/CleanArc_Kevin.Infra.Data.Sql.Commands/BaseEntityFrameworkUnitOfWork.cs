using CleanArc_Kevin.Core.Contracts.Data.Commands;

namespace CleanArc_Kevin.Infra.Data.Sql.Commands;

public abstract class BaseEntityFrameworkUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : BaseCommandDbContext
{
    protected readonly TDbContext DbContext;

    protected BaseEntityFrameworkUnitOfWork(TDbContext dbContext) => DbContext = dbContext;

    public void BeginTransaction() => DbContext.BeginTransaction();

    public int Commit()
    {
        var result = DbContext.SaveChanges();
        return result;
    }

    public async Task<int> CommitAsync()
    {
        var result = await DbContext.SaveChangesAsync();
        return result;
    }

    public void CommitTransaction() => DbContext.CommitTransaction();

    public void RollbackTransaction() => DbContext.RollbackTransaction();
}