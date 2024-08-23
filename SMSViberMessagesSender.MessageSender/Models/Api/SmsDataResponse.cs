namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsStatus
{
    public string Status { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal? Cost { get; set; }
}

public class SmsDataResponse
{
    public string MessageId { get; set; } = string.Empty;
    public SmsStatus Sms { get; set; } = new();
}