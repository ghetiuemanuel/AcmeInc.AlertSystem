using OptionOneTech.AlertSystem.Samples;
using Xunit;

namespace OptionOneTech.AlertSystem.EntityFrameworkCore.Applications;

[Collection(AlertSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AlertSystemEntityFrameworkCoreTestModule>
{

}
