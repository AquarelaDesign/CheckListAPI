using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListItensGroupController : ControllerBase
    {
        private readonly ICheckListItensGroupRepository _repository;
        private readonly IMapper _mapper;

        public CheckListItensGroupController(ICheckListItensGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itensGroup = await _repository.GetItensGroupAsync();
            return itensGroup.Any()
                    ? Ok(itensGroup)
                    : BadRequest("Grupo do item não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var itemGroup = await _repository.GetItensGroupByIdAsync(id);

            var itemGroupReturn = _mapper.Map<CheckListItensGroupDto>(itemGroup);


            return itemGroupReturn != null
                    ? Ok(itemGroupReturn)
                    : BadRequest("Grupo do item não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListItensGroupAddDto itemGroup)
        {
            if (itemGroup == null) return BadRequest("Dados Inválidos");

            var itemGroupAdd = _mapper.Map<CheckListItemGroup>(itemGroup);

            _repository.Add(itemGroupAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Grupo do item adicionado com sucesso")
                : BadRequest("Erro ao salvar o grupo do item");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListItensGroupAddDto itemGroup)
        {
            if (id < 0) return BadRequest("Grupo do item não informado");

            var dbCheck = await _repository.GetItensGroupByIdAsync(id);

            if (dbCheck == null) return NotFound("Grupo do item não encontrado");

            var itemGroupUpdate = _mapper.Map(itemGroup, dbCheck);

            _repository.Update(itemGroupUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Grupo do item atualizado com sucesso")
                : BadRequest("Erro ao atualizar o grupo do item");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Grupo do item não informado");

            var dbCheck = await _repository.GetItensGroupByIdAsync(id);

            if (dbCheck == null) return NotFound("Grupo do item não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Grupo do item deletado com sucesso")
                : BadRequest("Erro ao deletar o grupo do item");
        }
    }
}
