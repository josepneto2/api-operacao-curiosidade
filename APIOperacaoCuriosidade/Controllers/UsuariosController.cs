using APIOperacaoCuriosidade.Models;
using APIOperacaoCuriosidade.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIOperacaoCuriosidade.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase {
        private readonly IRepository<Usuario> _repository;

        public UsuariosController(IRepository<Usuario> repository) {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> BuscarTodos() {
            var usuarios = _repository.BuscarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Usuario> BuscarPorId(int id) {
            var usuario = _repository.BuscarPorId(u => u.Id == id);

            if (usuario == null) {
                return NotFound("Não encontrado");
            }

            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult Criar(Usuario usuario) {
            if (usuario == null) {
                return BadRequest("Dados inválidos");
            }

            var usuarioCriado = _repository.Criar(usuario);

            return CreatedAtAction("BuscarPorId", new { id = usuarioCriado.Id }, usuarioCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Atualizar(int id, Usuario usuario) {
            if (id != usuario.Id) {
                return BadRequest("Dados inválidos");
            }

            _repository.Atualizar(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Deletar(int id) {
            var usuario = _repository.BuscarPorId(u => u.Id == id);
            if(usuario == null) {
                return NotFound("Usuario não encontrado");
            }

            var usuarioDeletado = _repository.Deletar(usuario);
            return Ok(usuarioDeletado);
        }
    }
}
