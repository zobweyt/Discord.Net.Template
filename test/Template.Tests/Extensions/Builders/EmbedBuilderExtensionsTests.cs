using Bogus;
using Discord;
using Moq;
using Xunit;

namespace Template.Tests;

/// <summary>
/// Provides unit test cases for <see cref="EmbedBuilderExtensions"/>.
/// </summary>
public class EmbedBuilderExtensionsTests : TestsBase
{
    [Fact]
    public void WithStyle_Applies_Style_To_EmbedBuilder()
    {
        var embedBuilder = new EmbedBuilder();
        var embedStyleMock = new Mock<EmbedStyle>();

        embedStyleMock.Setup(s => s.Name).Returns(Faker.Lorem.Word());
        embedStyleMock.Setup(s => s.IconUrl).Returns(Faker.Internet.Avatar());
        embedStyleMock.Setup(s => s.Color).Returns(Faker.Random.RawColor());

        embedBuilder.WithStyle(embedStyleMock.Object);

        Assert.Equal(embedStyleMock.Object.Name, embedBuilder.Author.Name);
        Assert.Equal(embedStyleMock.Object.IconUrl, embedBuilder.Author.IconUrl);
        Assert.Equal(embedStyleMock.Object.Color, embedBuilder.Color);
    }
}
