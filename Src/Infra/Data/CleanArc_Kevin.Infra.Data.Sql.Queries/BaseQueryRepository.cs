using CleanArc_Kevin.Core.Contracts.Data.Queries;

namespace CleanArc_Kevin.Infra.Data.Sql.Queries;

public class BaseQueryRepository<TDbContext> : IQueryRepository where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext DbContext;

    public BaseQueryRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }
}