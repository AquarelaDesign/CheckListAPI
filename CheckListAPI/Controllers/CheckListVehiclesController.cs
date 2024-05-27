using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListVehiclesController : ControllerBase
    {
        private readonly ICheckListVehiclesRepository _repository;
        private readonly IMapper _mapper;

        public CheckListVehiclesController(ICheckListVehiclesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await _repository.GetVehicleAsync();
            return vehicles.Any()
                    ? Ok(vehicles)
                    : BadRequest("Veículo não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _repository.GetVehicleByIdAsync(id);

            var vehicleReturn = _mapper.Map<CheckListVehicleDto>(vehicle);


            return vehicleReturn != null
                    ? Ok(vehicleReturn)
                    : BadRequest("Veículo não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListVehicleAddDto vehicle)
        {
            if (vehicle == null) return BadRequest("Dados Inválidos");

            var vehicleAdd = _mapper.Map<CheckListVehicles>(vehicle);

            _repository.Add(vehicleAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Veículo adicionado com sucesso")
                : BadRequest("Erro ao salvar o veículo");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListVehicleAddDto vehicle)
        {
            if (id < 0) return BadRequest("Veículo não informado");

            var dbCheck = await _repository.GetVehicleByIdAsync(id);

            if (dbCheck == null) return NotFound("Veículo não encontrado");

            var vehicleUpdate = _mapper.Map(vehicle, dbCheck);

            _repository.Update(vehicleUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Veículo atualizado com sucesso")
                : BadRequest("Erro ao atualizar o Veículo");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Veículo não informado");

            var dbCheck = await _repository.GetVehicleByIdAsync(id);

            if (dbCheck == null) return NotFound("Veículo não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Veículo deletado com sucesso")
                : BadRequest("Erro ao deletar o veículo");
        }
    }
}
