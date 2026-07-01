using AcademyTask.Domain.Entities.Product;
using AcademyTask.Domain.Interfaces.Common;

namespace AcademyTask.Domain.Interfaces;

public interface IProductRepository : IRepository<Product, int> {}