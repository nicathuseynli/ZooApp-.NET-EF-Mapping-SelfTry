using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZooApp_EF.Data.Context;
using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF.Repository.Implementation
{
    public class CageRepository : ICageRepository
    {
        private readonly ZooDbContext _context;
        private readonly IMapper _mapper;

        public CageRepository(ZooDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CageDto> CreateAsync(CageDto cageDto)
        {
            await _context.Cages.AddAsync(_mapper.Map<Cage>(cageDto));
            await _context.SaveChangesAsync();
            return cageDto;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var result = await _context.Cages.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Cages.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cage>> GetAllAsync()
        {
            return await _context.Cages.ToListAsync();
        }

        public async Task<Cage> UpdateAsync(int Id,CageDto cageDto)
        {
            var cag = await _context.Cages.FirstOrDefaultAsync(x => x.Id == Id);
            if (cag == null)
                return null;
            var result = _mapper.Map<CageDto,Cage>(cageDto,cag);
            _context.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
