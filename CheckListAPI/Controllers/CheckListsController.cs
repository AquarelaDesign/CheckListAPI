using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize("Admin")]
    public class CheckListsController : ControllerBase
    {
        private readonly ICheckListsHeaderRepository _repository;
        private readonly IMapper _mapper;

        public CheckListsController(ICheckListsHeaderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var checklists = await _repository.GetCheckListAsync();
            return checklists.Any()
                    ? Ok(checklists)
                    : BadRequest("Checklist não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var checklist = await _repository.GetCheckListByIdAsync(id);

            var checklistReturn = _mapper.Map<CheckListHeaderDto>(checklist);

            return checklistReturn != null
                    ? Ok(checklistReturn)
                    : BadRequest("Checklist não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckListHeaderAddDto checklist)
        {
            if (checklist == null) return BadRequest("Dados Inválidos");

            var checklistAdd = _mapper.Map<CheckListHeader>(checklist);

            _repository.Add(checklistAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Checklist adicionado com sucesso")
                : BadRequest("Erro ao salvar o veículo");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CheckListHeaderAddDto checklist)
        {
            if (id < 0) return BadRequest("Checklist não informado");

            var dbCheck = await _repository.GetCheckListByIdAsync(id);

            if (dbCheck == null) return NotFound("Checklist não encontrado");

            var checklistUpdate = _mapper.Map(checklist, dbCheck);

            _repository.Update(checklistUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Checklist atualizado com sucesso")
                : BadRequest("Erro ao atualizar o checklist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Checklist não informado");

            var dbCheck = await _repository.GetCheckListByIdAsync(id);

            if (dbCheck == null) return NotFound("Checklist não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Checklist deletado com sucesso")
                : BadRequest("Erro ao deletar o veículo");
        }
    }
}
