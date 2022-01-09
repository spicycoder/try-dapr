using RestSharp;

namespace WeatherApi;

public class ConverterClient
{
    public RestClient Client { get; init; }

    public ConverterClient(Uri baseUri)
    {
        Client = new RestClient(baseUri);
    }
}