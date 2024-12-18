using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using AcmeInc.AlertSystem.Departments;
using Volo.Abp.EntityFrameworkCore.Modeling;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Messages;
using AcmeInc.AlertSystem.MessageSources;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Alerts;

namespace AcmeInc.AlertSystem.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AlertSystemDbContext :
    AbpDbContext<AlertSystemDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Department> Departments { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<WebhookMessageSource> WebhookMessageSources { get; set; }
    public DbSet<EmailMessageSource> EmailMessageSources { get; set; }
    public DbSet<Rule> Rules { get; set; }
    public DbSet<Alert> Alerts { get; set; }

    public AlertSystemDbContext(DbContextOptions<AlertSystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AlertSystemConsts.DbTablePrefix + "YourEntities", AlertSystemConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});


        builder.Entity<Department>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "Departments", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Level>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "Levels", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Status>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "Statuses", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Message>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "Messages", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<WebhookMessageSource>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "WebhookMessageSources", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<EmailMessageSource>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "EmailMessageSources", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Rule>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "Rules", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Alert>(b =>
        {
            b.ToTable(AlertSystemConsts.DbTablePrefix + "Alerts", AlertSystemConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });
    }
}
