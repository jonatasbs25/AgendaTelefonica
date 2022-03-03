using AgendaTelefonica.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTelefonica.API.Repositories
{
    //padrão Repository: isola a camada de acesso a dados com a camada de negócio (domínio) .
    //é criado uma interface de consulta e manipulação específica em coleção de dados
    //define um contrato que expõe os endpoints da api
    public interface IAgendaRepository
    {
        Task<List<Agenda>> ListarContatosAsync();
        Task<Agenda> ListarContatoPorNomeAsync(string nome);
        Task<int> SalvarContatoAsync(Agenda novoContato);
        Task<int> AtualizarContatoAsync(Agenda atualizarContato);
        Task<int> AtualizarNomeContatoAsync(Agenda atualizarContato);
        Task<int> AtualizarNumeroContatoAsync(Agenda atualizarContato);
        Task<int> DeletarContatoAsync(int id);
    }
}
