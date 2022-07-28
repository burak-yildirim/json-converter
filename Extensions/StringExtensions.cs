namespace ConvertJson.Extensions;

public static class StringExtensions
{
    // Reads lines one-by-one, lazily.
    public static IEnumerable<string> SplitToLines(this string mainStr)
    {
        if (string.IsNullOrEmpty(mainStr))
            yield break;

        string? line;
        using(var reader = new StringReader(mainStr))
        {
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
}
