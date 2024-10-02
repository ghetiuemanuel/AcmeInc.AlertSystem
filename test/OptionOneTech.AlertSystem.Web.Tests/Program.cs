using Microsoft.AspNetCore.Builder;
using OptionOneTech.AlertSystem;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AlertSystemWebTestModule>();

public partial class Program
{
}
