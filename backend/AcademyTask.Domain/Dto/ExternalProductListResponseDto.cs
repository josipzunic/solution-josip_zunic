namespace AcademyTask.Domain.Dto;

public class ExternalProductListResponseDto
{ 
    public List<ExternalProductDto>? Products { get; init; }
    public int Total { get; init; }
    public int Skip { get; init; }
    public int Limit { get; init; }
}