using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListOwnersController : ControllerBase
    {
        private readonly ICheckListOwnerRepository _repository;
        private readonly IMapper _mapper;

        public CheckListOwnersController(ICheckListOwnerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owneres = await _repository.GetOwnerAsync();
            return owneres.Any()
                    ? Ok(owneres)
                    : BadRequest("Proprietário não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var owner = await _repository.GetOwnerByIdAsync(id);

            var ownerReturn = _mapper.Map<CheckListOwnerDto>(owner);


            return ownerReturn != null
                    ? Ok(ownerReturn)
                    : BadRequest("Proprietário não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListOwnerAddDto owner)
        {
            if (owner == null) return BadRequest("Dados Inválidos");

            var ownerAdd = _mapper.Map<CheckListOwner>(owner);

            _repository.Add(ownerAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Proprietário adicionado com sucesso")
                : BadRequest("Erro ao salvar o proprietário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListOwnerAddDto owner)
        {
            if (id < 0) return BadRequest("Proprietário não informado");

            var dbCheck = await _repository.GetOwnerByIdAsync(id);

            if (dbCheck == null) return NotFound("Proprietário não encontrado");

            var ownerUpdate = _mapper.Map(owner, dbCheck);

            _repository.Update(ownerUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Proprietário atualizado com sucesso")
                : BadRequest("Erro ao atualizar o proprietário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Proprietário não informado");

            var dbCheck = await _repository.GetOwnerByIdAsync(id);

            if (dbCheck == null) return NotFound("Proprietário não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Proprietário deletado com sucesso")
                : BadRequest("Erro ao deletar o proprietário");
        }
    }
}
