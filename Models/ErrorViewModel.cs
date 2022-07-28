namespace ConvertJson.Models;

public class ErrorViewModel
{
    public bool IsDevelopment { get; set; }
    public string? ErrorMessage { get; set; }
    public Exception? Exception { get; set; }
    public int StatusCode { get; set; } = 400;
}
