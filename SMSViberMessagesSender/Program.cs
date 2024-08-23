using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSViberMessagesSender.MessageSender;
using SMSViberMessagesSender.MessageSender.Models.Options;
using SMSViberMessagesSender.MessageSender.Providers;
using SMSViberMessagesSender.MessageSender.Services;

namespace SMSViberMessagesSender;

public class Program
{
    public static async Task Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        
        var configuration = configurationBuilder.Build();
        var services = new ServiceCollection();
        
        services.AddSingleton(configuration);
        services.AddScoped<SmsFlyProvider>();
        services.AddScoped<MessageSenderService>();
        
        services.Configure<SmsFlyOptions>(
            configuration.GetSection(Constants.AppSettings.SMS_FLY_CONFIGURATION));
        
        var serviceProvider = services.BuildServiceProvider();
        var messageSenderService = serviceProvider.GetRequiredService<MessageSenderService>();

        // var response = await messageSenderService.SendTextSMSAsync("380684261065", "Test message from sender");
    }
}