using Newtonsoft.Json;

namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsStatusMessage
{
    [JsonProperty("messageID")]
    public string MessageId { get; set; } = string.Empty;
}