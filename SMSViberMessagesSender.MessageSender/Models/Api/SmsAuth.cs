using Newtonsoft.Json;

namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsAuth
{
    [JsonProperty("key")]
    public string Key { get; set; } = string.Empty;
}