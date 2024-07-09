using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;

namespace TfdInfo.ApiConsumer;

public class ModuleConsumer : IModuleConsumer
{
    private readonly HttpClient _httpClient;
    private readonly string _basePath = "https://open.api.nexon.com";
    private readonly string _moduleApiPath = "/static/tfd/meta/en/module.json";

    public ModuleConsumer()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_basePath)
        };
    }

    public async Task RequestMetaData()
    {
        var response = await _httpClient.GetAsync(_moduleApiPath);
        var contents = await response.Content.ReadAsStringAsync();
    }
}
