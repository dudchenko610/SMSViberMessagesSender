namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsError
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}