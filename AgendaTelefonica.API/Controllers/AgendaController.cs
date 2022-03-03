using AgendaTelefonica.API.Models;
using AgendaTelefonica.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgendaTelefonica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaRepository _agendaRepo;

        public AgendaController(IAgendaRepository agendaRepo)
        {
            _agendaRepo = agendaRepo;
        }

        [HttpGet] //requisição que solicita o retorno de dados
        [Route("contatos")] //propriedade que permite customizar o nome da rota da url
        public async Task<IActionResult> ListarContatosAsync()
        {
            var result = await _agendaRepo.ListarContatosAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("contato")]
        public async Task<IActionResult> ListarContatoPorNomeAsync(string nome)
        {
            var result = await _agendaRepo.ListarContatoPorNomeAsync(nome);
            return Ok(result);
        }

        [HttpPost] //requisiçao que solitica inserção de dados
        [Route("salvarcontato")]
        public async Task<IActionResult> SalvarContatoAsync(Agenda novoContato)
        {
            var result = await _agendaRepo.SalvarContatoAsync(novoContato);
            return Ok(result);
        }

        [HttpPut]
        [Route("atualizarcontato")]
        public async Task<IActionResult> AtualizarContatoAsync(Agenda atualizarContato)
        {
            var result = await _agendaRepo.AtualizarContatoAsync(atualizarContato);
            return Ok(result);
        }

        [HttpPatch]
        [Route("atualizarnome")]
        public async Task<IActionResult> AtualizarNomeContatoAsync(Agenda atualizarContato)
        {
            var result = await _agendaRepo.AtualizarNomeContatoAsync(atualizarContato);
            return Ok(result);
        }

        [HttpPatch]
        [Route("atualizarnumero")]
        public async Task<IActionResult> AtualizarNumeroContatoAsync(Agenda atualizarContato)
        {
            var result = await _agendaRepo.AtualizarNumeroContatoAsync(atualizarContato);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deletarcontato")]
        public async Task<IActionResult> DeletarContatoAsync(int id)
        {
            var result = await _agendaRepo.DeletarContatoAsync(id);
            return Ok(result);
        }
    }
}
