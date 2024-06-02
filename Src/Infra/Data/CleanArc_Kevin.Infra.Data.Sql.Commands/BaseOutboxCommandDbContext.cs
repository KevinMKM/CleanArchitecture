using CleanArc_Kevin.Core.Abstractions.Serializers;
using CleanArc_Kevin.Core.Abstractions.UsersManagement;
using CleanArc_Kevin.Infra.Data.Sql.Commands.Extensions;
using CleanArc_Kevin.Infra.Data.Sql.Commands.OutBoxEventItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArc_Kevin.Infra.Data.Sql.Commands;

public abstract class BaseOutboxCommandDbContext : BaseCommandDbContext
{
    public DbSet<OutBoxEventItem>? OutBoxEventItems { get; set; }

    protected BaseOutboxCommandDbContext(DbContextOptions options) : base(options)
    {
    }

    protected BaseOutboxCommandDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new OutBoxEventItemConfig());
    }

    protected override void BeforeSaveTriggers()
    {
        base.BeforeSaveTriggers();
        AddOutboxEventItems();
    }

    private void AddOutboxEventItems()
    {
        var changedAggregates = ChangeTracker.GetAggregatesWithEvent();
        var userInfoService = this.GetService<IUserInfoService>();
        var serializer = this.GetService<IJsonSerializer>();
        foreach (var aggregate in changedAggregates)
        {
            var events = aggregate.GetEvents();
            foreach (var @event in events)
            {
                OutBoxEventItems?.Add(new OutBoxEventItem
                {
                    EventId = Guid.NewGuid(),
                    OccurredByUserId = userInfoService.UserId(),
                    OccurredOn = DateTime.Now,
                    AggregateId = aggregate.BusinessId.ToString(),
                    AggregateName = aggregate.GetType().Name,
                    AggregateTypeName = aggregate.GetType().FullName,
                    EventName = @event.GetType().Name,
                    EventTypeName = @event.GetType().FullName,
                    EventPayload = serializer.Serialize(@event),
                    IsProcessed = false
                });
            }
        }
    }
}