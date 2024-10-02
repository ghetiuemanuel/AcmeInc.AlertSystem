using OptionOneTech.AlertSystem.Samples;
using Xunit;

namespace OptionOneTech.AlertSystem.EntityFrameworkCore.Domains;

[Collection(AlertSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AlertSystemEntityFrameworkCoreTestModule>
{

}
