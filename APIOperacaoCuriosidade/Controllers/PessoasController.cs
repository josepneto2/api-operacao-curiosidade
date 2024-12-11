using APIOperacaoCuriosidade.Models;
using APIOperacaoCuriosidade.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIOperacaoCuriosidade.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase {
        private readonly IPessoaRepository _repository;

        public PessoasController(IPessoaRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> BuscarTodos() {
            var pessoas = _repository.BuscarTodos();
            return Ok(pessoas);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pessoa> BuscarPorId(int id) {
            var pessoa = _repository.BuscarPorId(u => u.Id == id);

            if (pessoa == null) {
                return NotFound("Não encontrado");
            }

            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult<Pessoa> Criar(Pessoa pessoa) {
            if (pessoa == null) {
                return BadRequest("Dados inválidos");
            }

            var pessoaCriada = _repository.Criar(pessoa);

            return CreatedAtAction("BuscarPorId", new { id = pessoaCriada.Id }, pessoaCriada);
        }

        [HttpPut("{id:int}")]
        public ActionResult Atualizar(int id, Pessoa pessoa) {
            if (id != pessoa.Id) {
                return BadRequest("Dados inválidos");
            }

            var pessoaAtualizada = _repository.Atualizar(pessoa);
            return Ok(pessoaAtualizada);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletePessoa(int id) {
            var pessoa = _repository.BuscarPorId(p => p.Id == id);
            if (pessoa == null) {
                return NotFound("Usuario não encontrado");
            }

            var pessoaDeletada = _repository.Deletar(pessoa);
            return Ok(pessoaDeletada); ;
        }
    }
}
