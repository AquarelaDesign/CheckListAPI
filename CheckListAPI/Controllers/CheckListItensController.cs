using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListItensController : ControllerBase
    {
        private readonly ICheckListItensRepository _repository;
        private readonly IMapper _mapper;

        public CheckListItensController(ICheckListItensRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itens = await _repository.GetItensAsync();
            return itens.Any()
                    ? Ok(itens)
                    : BadRequest("Item não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetItensByIdAsync(id);

            var itemReturn = _mapper.Map<CheckListItensDto>(item);


            return itemReturn != null
                    ? Ok(itemReturn)
                    : BadRequest("Item não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListItensAddDto item)
        {
            if (item == null) return BadRequest("Dados Inválidos");

            var itemAdd = _mapper.Map<CheckListItens>(item);

            _repository.Add(itemAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Item adicionado com sucesso")
                : BadRequest("Erro ao salvar o item");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListItensAddDto item)
        {
            if (id < 0) return BadRequest("Item não informado");

            var dbCheck = await _repository.GetItensByIdAsync(id);

            if (dbCheck == null) return NotFound("Item não encontrado");

            var itemUpdate = _mapper.Map(item, dbCheck);

            _repository.Update(itemUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Item atualizado com sucesso")
                : BadRequest("Erro ao atualizar o item");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Item não informado");

            var dbCheck = await _repository.GetItensByIdAsync(id);

            if (dbCheck == null) return NotFound("Item não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Item deletado com sucesso")
                : BadRequest("Erro ao deletar o item");
        }
    }
}
