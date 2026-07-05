using System.Text.Json;
using AcademyTask.Domain.Dto;
using AcademyTask.Domain.Interfaces.ExternalApi;
using AcademyTask.Domain.Validation;
using AcademyTask.Domain.Validation.ValidationItems;
using Superpower.Model;

namespace AcademyTask.Infrastructure.ExternalApiFetch;

public class ExternalApiFetch : IProductSource
{
    private readonly HttpClient _httpClient;
    private readonly string? _api;
    
    public ExternalApiFetch(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _api =  Environment.GetEnvironmentVariable("EXTERNAL_API");
    }

    public async Task<Domain.Common.Model.Result<List<ExternalProductDto>>> GetProductsAsync()
    {
        if(_api == null)
            throw new InvalidOperationException("Please set the environment variable EXTERNAL_API");

        var response = await _httpClient.GetAsync(_api);
        response.EnsureSuccessStatusCode();

        var validationResult = new ValidationResult();
        var content = await response.Content.ReadAsStringAsync();
        var wrapper = JsonSerializer.Deserialize<ExternalProductListResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (wrapper == null || wrapper.Products == null)
        {
            validationResult.AddValidationItems(ValidationItems.Product.NullExternalProducts);
            return new Domain.Common.Model.Result<List<ExternalProductDto>>(null, validationResult);
        }

        return new Domain.Common.Model.Result<List<ExternalProductDto>>(wrapper.Products, validationResult);
    }
}