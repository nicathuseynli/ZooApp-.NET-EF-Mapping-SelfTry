using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;

namespace ZooApp_EF.Repository.Interface;
public interface ICageRepository
{
    public Task<CageDto> CreateAsync(CageDto cageDto);
    public Task<bool> DeleteAsync(int Id);
    public Task<Cage> UpdateAsync(int Id,CageDto cageDto);
    public Task<List<Cage>> GetAllAsync();
}
