namespace Chat.WebUI.Models;

public class ErrorViewModel
{
    public ErrorViewModel(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public ErrorViewModel(string message) : this(new List<string> { message })
    {
    }

    public IEnumerable<string> Errors { get; set; }
}