using System.Text.Json;
using System.Text.Json.Serialization;

namespace LaborationBlazor.Services;

public class ExchangeRateService
{
    private readonly HttpClient _httpClient;

    public ExchangeRateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
    {
        var response = await _httpClient.GetAsync($"exchangerate?pair={fromCurrency}_{toCurrency}");

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"API request failed: {response.StatusCode}, Content: {errorContent}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var exchangeRateData = JsonSerializer.Deserialize<ExchangeRateResponse>(content, options);

        return exchangeRateData?.ExchangeRate ?? 0;
    }

    private class ExchangeRateResponse
    {
        //[JsonPropertyName("currency_pair")]
        //public string CurrencyPair { get; set; }
        [JsonPropertyName("exchange_rate")]
        public decimal ExchangeRate { get; set; }
    }
}
