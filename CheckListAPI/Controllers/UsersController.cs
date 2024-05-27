using AutoMapper;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetUserAsync();
            return users.Any()
                    ? Ok(users)
                    : BadRequest("Usuário não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            var userReturn = _mapper.Map<UsersDto>(user);


            return userReturn != null
                    ? Ok(userReturn)
                    : BadRequest("Usuário não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsersAddDto user)
        {
            if (user == null) return BadRequest("Dados Inválidos");

            var dbCheck = await _repository.GetByEmailAsync(user.Email);

            if (dbCheck != null) return BadRequest("Usuário já cadastrado");

            var userAdd = _mapper.Map<Users>(user);

            _repository.Add(userAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuário adicionado com sucesso")
                : BadRequest("Erro ao salvar o usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsersAddDto user)
        {
            if (id < 0) return BadRequest("Usuário não informado");

            var dbCheck = await _repository.GetUserByIdAsync(id);

            if (dbCheck == null) return NotFound("Usuário não encontrado");
            
            var userUpdate = _mapper.Map(user, dbCheck);

            _repository.Update(userUpdate);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuário atualizado com sucesso")
                : BadRequest("Erro ao atualizar o usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest("Usuário não informado");

            var dbCheck = await _repository.GetUserByIdAsync(id);

            if (dbCheck == null) return NotFound("Usuário não encontrado");

            _repository.Delete(dbCheck);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuário deletado com sucesso")
                : BadRequest("Erro ao deletar o usuário");
        }
    }
}
