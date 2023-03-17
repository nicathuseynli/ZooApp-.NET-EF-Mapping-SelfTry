using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;

namespace ZooApp_EF.Repository.Interface;
public interface IZooRepository
{
    public Task<ZooDto> CreateAsync(ZooDto zooDto);
    public Task<bool> DeleteAsync(int Id);
    public Task<Zoo> UpdateAsync(int Id,ZooDto zooDto);
    public Task<List<Zoo>> GetAllAsync();
}
