using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SMSViberMessagesSender.MessageSender.Models.Api;
using SMSViberMessagesSender.MessageSender.Models.Options;

namespace SMSViberMessagesSender.MessageSender.Providers;

public class SmsFlyProvider(IOptions<SmsFlyOptions> _smsFlyOptions)
{
    private readonly HttpClient _httpClient = new ();
    private readonly SmsFlyOptions _smsFlyOptions = _smsFlyOptions.Value;

    public async Task<SmsResponse<TResult?>> SendAsync<TResult>(SmsRequest body)
        where TResult : class
    {
        body.Auth.Key = _smsFlyOptions.SecretKey;

        var request = new HttpRequestMessage(HttpMethod.Post, _smsFlyOptions.ApiUrl);
        request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await SendAsync<TResult>(request, _httpClient);

        return response;
    }
    
    public async Task<SmsResponse<TResult?>> SendAsync<TResult, TRequest>(SmsRequest<TRequest?> body)
        where TResult : class
        where TRequest : class
    {
        body.Auth.Key = _smsFlyOptions.SecretKey;
        
        var request = new HttpRequestMessage(HttpMethod.Post, _smsFlyOptions.ApiUrl);
        request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await SendAsync<TResult>(request, _httpClient);

        return response;
    }

    private async Task<SmsResponse<TResult?>> SendAsync<TResult>(HttpRequestMessage request, HttpClient httpClient)
        where TResult : class
    {
        try
        {
            using var response = await httpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SmsResponse<TResult?>>(content)!;
        }
        catch (Exception ex)
        {
            
        }

        return new SmsResponse<TResult?> { Success = 0 };
    }
}