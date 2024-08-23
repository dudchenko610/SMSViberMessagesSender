using Newtonsoft.Json;

namespace SMSViberMessagesSender.MessageSender.Models.Api;

public class SmsRequest
{
    [JsonProperty("auth")]
    public SmsAuth Auth { get; set; } = new();
    [JsonProperty("action")]
    public string Action { get; set; } = string.Empty;
}

public class SmsRequest<TData> : SmsRequest
{
    [JsonProperty("data")]
    public TData? Data { get; set; }
}