using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using CheckListAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public LoginController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto user, TokenService tokenService)
        {
            if (user == null) return BadRequest("Dados Inválidos");

            var dbCheck = await _repository.GetByEmailAsync(user.Email);

            if (dbCheck == null) return NotFound("Usuário não encontrado");

            AuthDto auth = new AuthDto
            {
                User = dbCheck,
                Token = tokenService.Generate(user)
            };
            return Ok(auth);
        }
    }
}
