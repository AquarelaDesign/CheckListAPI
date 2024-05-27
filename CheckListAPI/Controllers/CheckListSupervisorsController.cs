using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListSupervisorsController : ControllerBase
    {
        private readonly ICheckListSupervisorRepository _repository;
        private readonly IMapper _mapper;

        public CheckListSupervisorsController(ICheckListSupervisorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var supervisores = await _repository.GetSupervisorAsync();
            return supervisores.Any()
                    ? Ok(supervisores)
                    : BadRequest("Supervisor não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supervisor = await _repository.GetSupervisorByIdAsync(id);

            var supervisorReturn = _mapper.Map<CheckListSupervisorDto>(supervisor);


            return supervisorReturn != null
                    ? Ok(supervisorReturn)
                    : BadRequest("Supervisor não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListSupervisorAddDto supervisor)
        {
            if (supervisor == null) return BadRequest("Dados Inválidos");
            
            var supervisorAdd = _mapper.Map<CheckListSupervisor>(supervisor);

            _repository.Add(supervisorAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Supervisor adicionado com sucesso") 
                : BadRequest("Erro ao salvar o supervisor");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListSupervisorAddDto supervisor)
        {
            if (id < 0) return BadRequest("Supervisor não informado");

            var dbCheck = await _repository.GetSupervisorByIdAsync(id);

            if (dbCheck == null) return NotFound("Supervisor não encontrado");
            
            var supervisorUpdate = _mapper.Map(supervisor, dbCheck);
            
            _repository.Update(supervisorUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Supervisor atualizado com sucesso")
                : BadRequest("Erro ao atualizar o supervisor");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Supervisor não informado");

            var dbCheck = await _repository.GetSupervisorByIdAsync(id);

            if (dbCheck == null) return NotFound("Supervisor não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Supervisor deletado com sucesso")
                : BadRequest("Erro ao deletar o supervisor");
        }
    }
}
