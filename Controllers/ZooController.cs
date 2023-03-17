using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooApp_EF.Dto;
using ZooApp_EF.Repository.Implementation;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private readonly IZooRepository _zooRepository;

        public ZooController(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ZooDto zooDto)
        {
            var zooCre = await _zooRepository.CreateAsync(zooDto);
            return Ok(zooCre);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var zooGet = await _zooRepository.GetAllAsync();
            return Ok(zooGet);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var zooDel = await _zooRepository.DeleteAsync(id);
            if (zooDel == false)
                return NotFound();

            return Ok(zooDel);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id,ZooDto zooDto)
        {
            var zoo = await _zooRepository.UpdateAsync(Id, zooDto);
            if (zoo == null)
                return NotFound();
            return Ok(zoo);
        }
    }
}
