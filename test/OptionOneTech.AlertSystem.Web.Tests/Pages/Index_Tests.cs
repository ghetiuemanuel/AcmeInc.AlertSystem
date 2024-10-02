using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace OptionOneTech.AlertSystem.Pages;

public class Index_Tests : AlertSystemWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
