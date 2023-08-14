using Xunit;

namespace Template.Tests;

/// <summary>
/// Provides unit test cases for <see cref="InteractionResult"/>.
/// </summary>
public class InteractionResultTests : TestsBase
{
    [Theory]
    [InlineData(null)]
    [InlineData("Success")]
    public void InteractionResult_FromSuccess_Has_Null_Error(string? reason)
    {
        var result = InteractionResult.FromSuccess(reason);

        Assert.Null(result.Error);
        Assert.Equal(reason ?? string.Empty, result.ErrorReason);
    }

    [Fact]
    public void InteractionResult_FromError_Has_Expected_Reason()
    {
        var reason = Faker.Lorem.Word();
        var result = InteractionResult.FromError(reason);

        Assert.Equal(reason, result.ErrorReason);
    }
}
