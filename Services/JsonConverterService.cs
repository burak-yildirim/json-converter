using System.Xml;
using System.Xml.Linq;
using ConvertJson.Exceptions;
using Newtonsoft.Json;

namespace ConvertJson.Services;

public class JsonConverterService : IJsonConverterService
{
    public async Task<string> ToXmlStr(string jsonStr)
    {
        return await Task.Run(() =>
        {
            try
            {
                if (string.IsNullOrEmpty(jsonStr))
                    throw new JsonReaderException("Empty input!");
                
                var wrapped = jsonStr.StartsWith('[') ? $"{{ \"node\": {jsonStr} }}" : jsonStr;
                XNode xnode = JsonConvert.DeserializeXNode(wrapped, "root") ?? new XDocument();
                return xnode.ToString();
            }
            catch (JsonReaderException ex)
            {
                throw new UserFriendlyException(
                    "Json input must be valid and must not be empty!", ex);
            }
        });
    }
}
