using Newtonsoft.Json;

namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SourceChannelsRequest
{
    [JsonProperty("channels")]
    public List<string> Channels { get; set; } = new();
}