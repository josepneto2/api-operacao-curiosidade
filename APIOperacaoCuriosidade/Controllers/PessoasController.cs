using APIOperacaoCuriosidade.Models;
using APIOperacaoCuriosidade.Repositories;
using APIOperacaoCuriosidade.Utils;
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

            bool existe = _repository.Existe(p => p.Nome == pessoa.Nome || p.Email == pessoa.Email);
            if (existe) {
                return BadRequest("Pessoa já cadastrada");
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
                return NotFound("Pessoa não encontrada");
            }

            var pessoaDeletada = _repository.Deletar(pessoa);
            return Ok(pessoaDeletada); ;
        }

        [HttpGet("{busca}")]
        public ActionResult<Pessoa> BuscarPorNomeEmail(string busca) {
            if (string.IsNullOrEmpty(busca)) {
                return BadRequest("A busca não pode ser vazia");
            }

            var pessoa = _repository.BuscarPorNomeEmail(p => 
                p.Nome.ToLower().Contains(busca.ToLower()) ||
                p.Email.ToLower().Contains(busca.ToLower())
            );

            if (pessoa == null) {
                return NotFound("Pessoa não encontrada");
            }

            return Ok(pessoa);
        }

        [HttpGet("dashboardInfos")]
        public ActionResult<DashboardInfos> QuantidadeCadastros() {
            var cadastros = _repository.BuscarTodos();
            int totalCadastros = cadastros.Count();
            int quantidadeCadastrosUltimoMes = DashboardUtils.QuantidadeCadastrosUltimoMes(cadastros);
            int quantidadeCadastrosPendentes = DashboardUtils.QuantidadeCadastrosPendentes(cadastros);

            DashboardInfos dashboardInfos = new DashboardInfos(totalCadastros, quantidadeCadastrosUltimoMes, quantidadeCadastrosPendentes);
            return Ok(dashboardInfos);
        }
    }
}
