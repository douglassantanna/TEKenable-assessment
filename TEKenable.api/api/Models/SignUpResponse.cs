namespace api.Models;

public class SignUpResponse
{
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
    public bool Success { get; set; } = true;
}
