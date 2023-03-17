using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooApp_EF.Dto;
using ZooApp_EF.Repository.Implementation;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CageController : ControllerBase
    {
        private readonly ICageRepository _cageRepository;

        public CageController(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CageDto cageDto)
        {
            var cageCre = await _cageRepository.CreateAsync(cageDto);
            return Ok(cageCre);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var cageGet = await _cageRepository.GetAllAsync();
            return Ok(cageGet);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var cageDel = await _cageRepository.DeleteAsync(id);
            if (cageDel == false)
                return NotFound();

            return Ok(cageDel);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id,CageDto cageDto)
        {
            var cageUp = await _cageRepository.UpdateAsync(Id,cageDto);
            if (cageUp == null)
                return NotFound();
            return Ok(cageUp);
        }
    }
}
