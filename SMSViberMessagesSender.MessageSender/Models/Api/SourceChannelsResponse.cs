using Newtonsoft.Json;

namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SourceChannelsResponse
{
    [JsonProperty("sms")]
    public List<string> Sms { get; set; } = new();
    
    [JsonProperty("viber")]
    public List<string> Viber { get; set; } = new();
}