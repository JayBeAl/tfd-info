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
            BaseAddress = new Uri(_basePath);
        }
    }

    public void RequestMetaData()
    {
        var stream = await _httpClient.GetStreamAsync(_moduleApiPath);

        // Read V3 as YAML
        var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);

        // Write V2 as JSON
        var outputString = openApiDocument.Serialize(OpenApiSpecVersion.OpenApi2_0, OpenApiFormat.Json);
    }
}
