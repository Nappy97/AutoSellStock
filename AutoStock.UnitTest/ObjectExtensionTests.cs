using AutoStock.Shared.Extension;
using FluentAssertions;

namespace AutoStock.UnitTest;

[TestClass]
public class ObjectExtensionTests
{
    [TestMethod]
    public void QueryParameterTest()
    {
        var data = new
        {
            userName = "정의형",
            age = 20
        };
        var result = data.ToQueryParameter();
        result.Should().Be("?userName=정의형&age=20");
    }
}
