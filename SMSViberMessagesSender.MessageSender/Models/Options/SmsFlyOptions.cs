namespace SMSViberMessagesSender.MessageSender.Models.Options;

public class SmsFlyOptions
{
    public required string ApiUrl { get; set; }
    public required string SecretKey { get; set; }
    public required int Ttl { get; set; }
    public required string AlphaName { get; set; }
}