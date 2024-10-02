using Xunit;

namespace OptionOneTech.AlertSystem.EntityFrameworkCore;

[CollectionDefinition(AlertSystemTestConsts.CollectionDefinitionName)]
public class AlertSystemEntityFrameworkCoreCollection : ICollectionFixture<AlertSystemEntityFrameworkCoreFixture>
{

}
