using System.Text.RegularExpressions;

namespace proAdministration.Data.Common;

public static partial class FormatHelpers
{
    [GeneratedRegex("[,\\s&.-]+")]
    private static partial Regex SpecialCharacters();

    /// <summary>
    /// Cleans up the string by removing specific special characters and whitespace making the name suitable for an email host provider.
    /// </summary>
    /// <param name="name">The company name to clean-up.</param>
    /// <param name="replacement">symbol used to replace discrepancies with. default '-'</param>
    /// <returns>A formatted company name.</returns>
    public static string FormatBogusCompanyName(string name, string replacement = "-") =>
        SpecialCharacters().Replace(name, replacement);
}