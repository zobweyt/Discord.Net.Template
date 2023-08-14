using Bogus;
using Discord;
using Moq;
using Xunit;

namespace Template.Tests;

/// <summary>
/// Provides unit test cases for <see cref="UserExtensions"/>.
/// </summary>
public class UserExtensionsTests : TestsBase
{
    [Fact]
    public void GetDisplayAvatarUrl_Should_Return_GetDefaultAvatarUrl_When_GetAvatarUrl_Is_Null()
    {
        var userMock = new Mock<IUser>();
        var defaultAvatarUrl = Faker.Internet.Avatar();

        userMock.Setup(x => x.GetAvatarUrl(It.IsAny<ImageFormat>(), It.IsAny<ushort>())).Returns((string)null);
        userMock.Setup(x => x.GetDefaultAvatarUrl()).Returns(defaultAvatarUrl);

        var displayAvatarUrl = userMock.Object.GetDisplayAvatarUrl();

        Assert.Equal(displayAvatarUrl, defaultAvatarUrl);
    }
}
