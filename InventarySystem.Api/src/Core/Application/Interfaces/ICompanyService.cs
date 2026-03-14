using InventarySystem.Api.src.Core.Application.DTOs;

namespace InventarySystem.Api.src.Core.Application.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetAllActiveAsync();
    Task<CompanyDto?> GetByIdAsync(int id);
    Task<CompanyDto> CreateAsync(CompanyCreateDto dto);
    Task DeactivateAsync(int id);
}