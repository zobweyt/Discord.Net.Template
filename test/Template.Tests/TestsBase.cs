using Bogus;

namespace Template.Tests;

/// <summary>
/// The base abstract class for defining unit test cases.
/// </summary>
public abstract class TestsBase
{
    protected virtual Faker Faker { get; } = new();
}
