using System.Text;

namespace Chat.Application.Common.Models;

public record Result(bool Succeed, string[] Message)
{
    public static Result Success() => new(true, new string[] {});

    public static Result Success(IEnumerable<string> message) => new(true, message.ToArray());
    
    public static Result Success(string message) => new(true, new []{ message });

    public static Result Failure(string message) => new(false, new[] { message });
    
    public static Result Failure(IEnumerable<string> message) => new(false, message.ToArray());
    
    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var item in Message)
            sb.Append(item);

        return sb.ToString();
    }
}