using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListItensVehicleController : ControllerBase
    {
        private readonly ICheckListItensVehicleRepository _repository;
        private readonly IMapper _mapper;

        public CheckListItensVehicleController(ICheckListItensVehicleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itens = await _repository.GetItensVehicleAsync();
            return itens.Any()
                    ? Ok(itens)
                    : BadRequest("Item do veículo não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetItensVehicleByIdAsync(id);

            var itemReturn = _mapper.Map<CheckListItensVehicleDto>(item);


            return itemReturn != null
                    ? Ok(itemReturn)
                    : BadRequest("Item do veículo não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListItensVehicleAddDto item)
        {
            if (item == null) return BadRequest("Dados Inválidos");

            var itemAdd = _mapper.Map<CheckListItensVehicle>(item);

            _repository.Add(itemAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Item do veículo adicionado com sucesso")
                : BadRequest("Erro ao salvar o item do veículo");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListItensVehicleAddDto item)
        {
            if (id < 0) return BadRequest("Item do veículo não informado");

            var dbCheck = await _repository.GetItensVehicleByIdAsync(id);

            if (dbCheck == null) return NotFound("Item do veículo não encontrado");

            var itemUpdate = _mapper.Map(item, dbCheck);

            _repository.Update(itemUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Item do veículo atualizado com sucesso")
                : BadRequest("Erro ao atualizar o item do veículo");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Item do veículo não informado");

            var dbCheck = await _repository.GetItensVehicleByIdAsync(id);

            if (dbCheck == null) return NotFound("Item do veículo não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Item do veículo deletado com sucesso")
                : BadRequest("Erro ao deletar o item do veículo");
        }
    }
}
