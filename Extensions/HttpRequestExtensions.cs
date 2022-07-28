using System.Text;

namespace ConvertJson.Extensions;

public static class HttpRequestExtensions
{
    public static async Task<string> GetBodyAsString(this HttpRequest req,
        Encoding? encoding = null)
    {
        if (!req.Body.CanSeek)
        {
            req.EnableBuffering();
        }

        req.Body.Seek(0, SeekOrigin.Begin);
        var reqBodyStr = await new StreamReader(req.Body, encoding ?? Encoding.UTF8)
            .ReadToEndAsync();
        req.Body.Seek(0, SeekOrigin.Begin);
        return reqBodyStr;
    }
}
