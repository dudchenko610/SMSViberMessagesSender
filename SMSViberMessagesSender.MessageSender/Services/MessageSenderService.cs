using Microsoft.Extensions.Options;
using SMSViberMessagesSender.MessageSender.Models.Api;
using SMSViberMessagesSender.MessageSender.Models.Options;
using SMSViberMessagesSender.MessageSender.Providers;

namespace SMSViberMessagesSender.MessageSender.Services;

public class MessageSenderService(SmsFlyProvider _smsFlyProvider, IOptions<SmsFlyOptions> _smsFlyOptions)
{
    public Task<SmsResponse<SmsDataResponse?>> SendSMSTextMessageAsync(string phoneNumber, string message)
    {
        return _smsFlyProvider
            .SendAsync<SmsDataResponse, SmsSendMessage>(new SmsRequest<SmsSendMessage?>
            {
                Action = Constants.SmsFlyActions.SENDMESSAGE,
                Data = new SmsSendMessage
                {
                    Recipient = phoneNumber,
                    Channels = new List<string> { "sms" },
                    Sms = new SmsModel
                    {
                        Source = _smsFlyOptions.Value.AlphaName,
                        Ttl = _smsFlyOptions.Value.Ttl,
                        Text = message
                    }
                }
            });
    }
    
    public Task<SmsResponse<SmsDataResponse?>> SendViberTextMessageAsync(string phoneNumber, string message)
    {
        return _smsFlyProvider
            .SendAsync<SmsDataResponse, SmsSendMessage>(new SmsRequest<SmsSendMessage?>
            {
                Action = Constants.SmsFlyActions.SENDMESSAGE,
                Data = new SmsSendMessage
                {
                    Recipient = phoneNumber,
                    Channels = new List<string> { "viber" },
                    Viber = new SmsModel
                    {
                        Source = _smsFlyOptions.Value.AlphaName,
                        Ttl = _smsFlyOptions.Value.Ttl,
                        Text = message
                    }
                }
            });
    }
}