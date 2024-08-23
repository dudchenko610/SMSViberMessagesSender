
using Newtonsoft.Json;

namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsSendMessage
{
    [JsonProperty("recipient")]
    public string Recipient { get; set; } = string.Empty;
    [JsonProperty("channels")]
    public List<string> Channels { get; set; } = new();
    [JsonProperty("sms")]
    public SmsModel? Sms { get; set; }
    [JsonProperty("viber")]
    public SmsModel? Viber { get; set; }
}

public class SmsModel
{
    [JsonProperty("source")]
    public string Source { get; set; } = string.Empty;
    [JsonProperty("ttl")]
    public int Ttl { get; set; }
    [JsonProperty("text")]
    public string Text { get; set; } = string.Empty;
}