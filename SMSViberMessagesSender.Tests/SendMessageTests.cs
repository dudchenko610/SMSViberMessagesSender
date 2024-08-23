using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using SMSViberMessagesSender.MessageSender;
using SMSViberMessagesSender.MessageSender.Models.Api;
using SMSViberMessagesSender.MessageSender.Models.Options;
using SMSViberMessagesSender.MessageSender.Providers;
using SMSViberMessagesSender.MessageSender.Services;

namespace SMSViberMessagesSender.Tests;

public class Tests
{
    private const string PhoneNumber = "380XXXXXXXXX"; // 380XXXXXXXXX
    private const string Message = "Test message from NUnit";
    
    private SmsFlyProvider? _smsFlyProvider;
    private MessageSenderService? _messageSenderService;
    
    [SetUp]
    public async Task Setup()
    {
        var services = new ServiceCollection();
        
        var mockOptions = new Mock<IOptions<SmsFlyOptions>>();
        mockOptions.Setup(o => o.Value).Returns(new SmsFlyOptions
        {
            ApiUrl = "https://sms-fly.ua/api/v2/api.php",
            SecretKey = "",
            Ttl = 1,
            AlphaName = ""
        });

        services.AddTransient<IOptions<SmsFlyOptions>>(_ => mockOptions.Object);
        
        services.AddScoped<SmsFlyProvider>();
        services.AddScoped<MessageSenderService>();
        
        var serviceProvider = services.BuildServiceProvider();
        _smsFlyProvider = serviceProvider.GetRequiredService<SmsFlyProvider>();
        _messageSenderService = serviceProvider.GetRequiredService<MessageSenderService>();
    }

    [Test]
    public async Task SendSMSMessageAsync()
    {
        Assert.False(_messageSenderService is null);
        
        var response = await _messageSenderService!.SendSMSTextMessageAsync(PhoneNumber, Message);
        Assert.True(response?.Success == 1);
    }
    
    [Test]
    public async Task SendViberMessageAsync()
    {
        Assert.False(_messageSenderService is null);
        
        var response = await _messageSenderService!.SendViberTextMessageAsync(PhoneNumber, Message);
        Assert.True(response?.Success == 1);
    }
    
    [Test]
    public async Task GetSourceChannelsAsync()
    {
        Assert.False(_smsFlyProvider is null);

        var response = await _smsFlyProvider.SendAsync<SourceChannelsResponse, SourceChannelsRequest>(
            new SmsRequest<SourceChannelsRequest?>
            {
                Action = Constants.SmsFlyActions.GETSOURCES,
                Data = new SourceChannelsRequest
                {
                    Channels = new List<string>() { "sms", "viber" }
                }
            });
    }
}