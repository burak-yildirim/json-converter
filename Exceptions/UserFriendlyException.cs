namespace ConvertJson.Exceptions;

/// <summary>
/// This class is for transforming exceptions into user friendly error messages,
/// without losing exception details. It helps managing global exception handling.
/// </summary>
public class UserFriendlyException : Exception
{
    public int StatusCode { get; set; } = 400; // Bad Request

    public UserFriendlyException(string friendlyMessage, Exception? innerException = null)
        : base(friendlyMessage, innerException)
    { }
}
