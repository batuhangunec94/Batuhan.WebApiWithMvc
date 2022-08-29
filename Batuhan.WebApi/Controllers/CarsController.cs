using Batuhan.WebApi.Entities;
using Batuhan.WebApi.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Batuhan.WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carRepository.GetAllCarAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCar(int id)
        {
            var result = await _carRepository.GetByIdCarAsync(id);
            if (result == null)
            {
                return NotFound(id);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Car model)
        {
            var result = await _carRepository.CreateCarAsync(model);
            if (result)
            {
                return Created(string.Empty, model);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Car model)
        {
            if (model.Id > 0)
            {
                var resultChecked = await _carRepository.GetByIdCarAsync(model.Id);
                if (resultChecked == null)
                {
                    return NotFound();
                }
                else
                {
                    await _carRepository.UpdateCarAsync(model);
                    return NoContent();
                }
            }
            else
            {
                return NotFound("Geçersiz Id");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var resultChecked = await _carRepository.GetByIdCarAsync(id);
                if (resultChecked != null)
                {
                    await _carRepository.RemoveCarAsync(id);
                    return Ok(id);
                }
                else
                {
                    return NotFound(id);
                }

            }
            else
            {
                return NotFound("Geçersiz Id");
            }
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
       {
            var fileName = Guid.NewGuid()+"."+Path.GetExtension(file.Name);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            var stream = new FileStream(path,FileMode.Create);
            await stream.CopyToAsync(stream);
            return Created(string.Empty,file);
       }
    }
}
