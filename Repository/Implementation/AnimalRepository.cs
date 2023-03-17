using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZooApp_EF.Data.Context;
using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF.Repository.Implementation;
public class AnimalRepository : IAnimalRepository
{
    private readonly ZooDbContext _context;
    private readonly IMapper _mapper;
       
    public AnimalRepository(ZooDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Animal> AddAnimalAsync(AnimalDto animalDto)
    {
       var ani = await _context.Animals.AddAsync(_mapper.Map<Animal>(animalDto));
        await _context.SaveChangesAsync();
        return ani;
    }
    public async Task<AnimalDto> CreateAsync(AnimalDto animalDto)
    {
        await _context.Animals.AddAsync(_mapper.Map<Animal>(animalDto));
        await _context.SaveChangesAsync();
        return animalDto;
    }

    public async Task<bool> DeleteAsync(int Id)
    {
        var result = await _context.Animals.FirstOrDefaultAsync(x => x.Id==Id);
        _context.Animals.Remove(result);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Animal>> GetAllAsync()
    {
        return await _context.Animals.ToListAsync();
    }

    public async Task<Animal> UpdateAsync(int Id,AnimalDto animalDto)
    {
        var aniUpd = await _context.Animals.FirstOrDefaultAsync(x => x.Id == Id);
        if (aniUpd == null)
            return null;
        var result = _mapper.Map<AnimalDto,Animal>(animalDto, aniUpd);
        _context.Update(result);
        await _context.SaveChangesAsync();
        return result;
    }
}
