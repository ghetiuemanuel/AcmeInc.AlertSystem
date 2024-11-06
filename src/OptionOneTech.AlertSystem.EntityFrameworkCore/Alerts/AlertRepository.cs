using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Alerts;

public class AlertRepository : EfCoreRepository<AlertSystemDbContext, Alert, Guid>, IAlertRepository
{
    public AlertRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Alert>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<List<Alert>> GetLookupListAsync(int skip, int take, bool includeInActive)
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Select(alert => new Alert(alert.Id, alert.Title, "", Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    public async Task<IQueryable<AlertNavigation>> GetNavigationList()
    {
        var dbContext = await GetDbContextAsync();

        var query =
            from alert in dbContext.Alerts
            join department in dbContext.Departments
            on alert.DepartmentId equals department.Id into departmentGroup
            from department in departmentGroup.DefaultIfEmpty()
            join level in dbContext.Levels
            on alert.LevelId equals level.Id into levelGroup
            from level in levelGroup.DefaultIfEmpty()
            join status in dbContext.Statuses
            on alert.StatusId equals status.Id into statusGroup
            from status in statusGroup.DefaultIfEmpty()
            join message in dbContext.Messages
            on alert.MessageId equals message.Id into messageGroup
            from message in messageGroup.DefaultIfEmpty()
            join rule in dbContext.Rules
            on alert.RuleId equals rule.Id into rulesGroup
            from rule in rulesGroup.DefaultIfEmpty()
            select new AlertNavigation
            {
                Alert = alert,
                Department = department,
                Level = level,
                Status = status,
                Message = message,
                Rule = rule
            };

        return query;
    }
}