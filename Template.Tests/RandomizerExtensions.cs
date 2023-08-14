using Bogus;
using Discord;

namespace Template.Tests;

/// <summary>
/// Provides extension methods for <see cref="Randomizer"/>.
/// </summary>
public static class RandomizerExtensions
{
    /// <summary>
    /// Generates a random raw color value considering the <see cref="Color.MaxDecimalValue"/>.
    /// </summary>
    /// <param name="randomizer">The randomizer to use for generation.</param>
    /// <returns>A random raw color value.</returns>
    public static uint RawColor(this Randomizer randomizer) => randomizer.UInt(max: Color.MaxDecimalValue);
}
