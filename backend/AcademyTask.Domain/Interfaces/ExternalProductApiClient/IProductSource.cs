using AcademyTask.Domain.Common.Model;
using AcademyTask.Domain.Dto;

namespace AcademyTask.Domain.Interfaces.ExternalApi;

public interface IProductSource
{
    Task<Result<List<ExternalProductDto>>> GetProductsAsync();
}