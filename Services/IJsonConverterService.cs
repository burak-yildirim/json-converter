namespace ConvertJson.Services;

public interface IJsonConverterService
{
    /// <summary>
    /// Gets json input as string and converts it to xml and returns as string.
    /// </summary>
    /// <param name="jsonStr"></param>
    /// <returns>xml as string</returns>
    Task<string> ToXmlStr(string jsonStr);
}
