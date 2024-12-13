using APIOperacaoCuriosidade.Models;
using APIOperacaoCuriosidade.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIOperacaoCuriosidade.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository) {
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

            bool existe = _repository.Existe(p => p.Nome == usuario.Nome || p.Email == usuario.Email);
            if (existe) {
                return BadRequest("Usuário já cadastrado");
            }

            var usuarioCriado = _repository.Criar(usuario);

            return CreatedAtAction("BuscarPorId", new { id = usuarioCriado.Id }, usuarioCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Atualizar(int id, Usuario usuario) {
            if (id != usuario.Id) {
                return BadRequest("Dados inválidos");
            }

            var usuarioAtualizado = _repository.Atualizar(usuario);
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

        [HttpGet("filtrar/{busca}")]
        public ActionResult<IEnumerable<Usuario>> FiltrarPorNomeEmail(string busca) {
            if (string.IsNullOrEmpty(busca)) {
                return BadRequest("A busca não pode ser vazia");
            }

            var usuarios = _repository.FiltrarPorNomeEmail(p =>
                p.Nome.ToLower().Contains(busca.ToLower()) ||
                p.Email.ToLower().Contains(busca.ToLower())
            );

            if (usuarios == null) {
                return NotFound("Pessoa não encontrada");
            }

            return Ok(usuarios);
        }

        [HttpGet("{busca}")]
        public ActionResult<Usuario> BuscarPorNomeEmail(string busca) {
            if (string.IsNullOrEmpty(busca)) {
                return BadRequest("A busca não pode ser vazia");
            }

            var usuario = _repository.BuscarPorNomeEmail(p =>
                p.Nome.ToLower().Contains(busca.ToLower()) ||
                p.Email.ToLower().Contains(busca.ToLower())
            );

            if (usuario == null) {
                return NotFound("Pessoa não encontrada");
            }

            return Ok(usuario);
        }
    }
}
