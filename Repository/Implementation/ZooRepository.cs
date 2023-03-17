using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZooApp_EF.Data.Context;
using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF.Repository.Implementation
{
    public class ZooRepository : IZooRepository
    {
        private readonly ZooDbContext _context;
        private readonly IMapper _mapper;

        public ZooRepository(ZooDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ZooDto> CreateAsync(ZooDto zooDto)
        {
            await _context.Zoos.AddAsync(_mapper.Map<Zoo>(zooDto));
            await _context.SaveChangesAsync();
            return zooDto;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var result = await _context.Zoos.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Zoos.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Zoo>> GetAllAsync()
        {
            return await _context.Zoos.ToListAsync();
            //bes hec ne yoxdursa bos array gaytarir onu nece duzeldim sozle yazim ki zoo is not found
        }

        public async Task<Zoo> UpdateAsync(int Id,ZooDto zooDto)
        {
            var zoo = await _context.Zoos.FirstOrDefaultAsync(x => x.Id == Id);
            if (zoo == null)
                return null;
            var result = _mapper.Map<ZooDto,Zoo>(zooDto,zoo);
            _context.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
