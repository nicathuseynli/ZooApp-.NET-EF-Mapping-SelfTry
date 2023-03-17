using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooApp_EF.Dto;
using ZooApp_EF.Repository.Implementation;
using ZooApp_EF.Repository.Interface;

namespace ZooApp_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AnimalDto animalDto)
        {
            var animalCre = await _animalRepository.CreateAsync(animalDto);
            return Ok(animalCre);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var animalGet = await _animalRepository.GetAllAsync();
            return Ok(animalGet);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var animalRem = await _animalRepository.DeleteAsync(id);
            if (animalRem == false)
                return NotFound();

            return Ok(animalRem);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id, AnimalDto animalDto)
        {
            var animalUp = await _animalRepository.UpdateAsync(Id,animalDto);
            if (animalUp == null)
                return NotFound();

            return Ok(animalUp);
        }
        [HttpPut("AddAnimal")]
        public async Task<IActionResult> AddAnimal(int Id,AnimalDto animalDto)
        {
            var animalAdd = await _animalRepository.CreateAsync(animalDto);
            return Ok(animalAdd);
        }
    }
}
