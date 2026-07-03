using System.Text.Json;
using AcademyTask.Domain.Dto;
using AcademyTask.Domain.Interfaces.ExternalApi;
using AcademyTask.Domain.Validation;
using AcademyTask.Domain.Validation.ValidationItems;
using Superpower.Model;

namespace AcademyTask.Infrastructure.ExternalApiFetch;

public class ExternalProductApiClient : IExternalProductApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string? _api;
    
    public ExternalProductApiClient(HttpClient httpClient)
    {
        DotNetEnv.Env.Load();
        _httpClient = httpClient;
        _api =  Environment.GetEnvironmentVariable("EXTERNAL_API");
    }

    public async Task<Domain.Common.Model.Result<List<ExternalProductDto>>> GetProductsAsync()
    {
        DotNetEnv.Env.Load();
        string? api = Environment.GetEnvironmentVariable("EXTERNAL_API");
        
        if(api == null)
            throw new InvalidOperationException("Please set the environment variable EXTERNAL_API");

        var response = await _httpClient.GetAsync(_api);
        response.EnsureSuccessStatusCode();

        var validationResult = new ValidationResult();
        var content = await response.Content.ReadAsStringAsync();
        var externalProducts =
            JsonSerializer.Deserialize<List<ExternalProductDto>>(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        if (externalProducts == null)
        {
            validationResult.AddValidationItems(ValidationItems.Product.NullExternalProducts);
            return new Domain.Common.Model.Result<List<ExternalProductDto>>(null,  validationResult);
        }
        return new Domain.Common.Model.Result<List<ExternalProductDto>>(externalProducts, validationResult);
    }
}