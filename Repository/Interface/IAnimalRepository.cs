using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;

namespace ZooApp_EF.Repository.Interface;
public interface IAnimalRepository
{
    public Task<AnimalDto> CreateAsync(AnimalDto animalDto);
    public Task<Animal> UpdateAsync(int Id,AnimalDto animalDto);
    public Task<bool> DeleteAsync(int Id);
    public Task<List<Animal>> GetAllAsync();
    public Task<Animal> AddAnimalAsync(AnimalDto animalDto);
}
