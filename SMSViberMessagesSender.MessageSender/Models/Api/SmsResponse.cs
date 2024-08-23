namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsResponse<TData>
{
    public int Success { get; set; }
    public DateTime? Date { get; set; }
    public TData? Data { get; set; }
    public SmsError? Error { get; set; }
}