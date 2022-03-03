using AgendaTelefonica.API.Data;
using AgendaTelefonica.API.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.API.Repositories
{
    //A classe AgendaRepository herda e implementa os métodos da interface IAgendaRepository.
    //As regras de negócio para definir como serão implementados os métodos
    //serão feitas nessa classe.
    public class AgendaRepository : IAgendaRepository
    {
        //private readonly Banco _db; //váriavel somente para leitura
        private Banco _db;

        //Ao iniciar o objeto AgendaRepository, a conexão com o banco
        //será passada como parâmetro para que as transações sejam executadas.
        public AgendaRepository(Banco banco)
        {
            _db = banco;
        }

        //método assíncrono
        public async Task<List<Agenda>> ListarContatosAsync()
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = "SELECT * FROM Agenda";
                List<Agenda> contatos = (await conn.QueryAsync<Agenda>(sql: sqlQuery)).ToList();
                //executa uma consulta assíncrona e retorna uma lista
                return contatos;
            }
            //throw new System.NotImplementedException();
        }

        //SELECT * FROM AGENDA WHERE REGEX_LIKE() 
        public async Task<Agenda> ListarContatoPorNomeAsync(string nome)
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = @"SELECT * FROM Agenda WHERE Nome = @Nome";
                Agenda contato = await conn.QueryFirstOrDefaultAsync<Agenda>
                    (sql: sqlQuery, param: new { nome });
                return contato;
            }
            //throw new System.NotImplementedException();
        }

        //INSERT FROM AGENDA(Nome, NumContato) VALUES()
        public async Task<int> SalvarContatoAsync(Agenda novoContato)
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = @"INSERT INTO Agenda(Nome, NumContato) VALUES(@Nome, @NumContato)";
                var result = await conn.ExecuteAsync(sql: sqlQuery, param: novoContato);
                //Executa uma transação assíncrona que passa como parâmetros
                //a query sql e objeto afetado.
                return result;
            }
            //throw new System.NotImplementedException();
        }

        //UPDATE AGENDA SET Nome = , NumContato = WHERE Id =
        public async Task<int> AtualizarContatoAsync(Agenda atualizarContato)
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = @"
                    UPDATE Agenda 
                        SET Nome = @Nome, 
                            NumContato = @NumContato
                        WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: sqlQuery, param: atualizarContato);
                return result;
            }
            //throw new System.NotImplementedException();
        }

        //UPDATE AGENDA SET Nome = WHERE Id =
        public async Task<int> AtualizarNomeContatoAsync(Agenda atualizarContato)
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = @"UPDATE Agenda SET Nome = @Nome WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: sqlQuery, param: atualizarContato);
                return result;
            }
            //throw new System.NotImplementedException();
        }

        //UPDATE AGENDA SET NumContato = WHERE Id =
        public async Task<int> AtualizarNumeroContatoAsync(Agenda atualizarContato)
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = @"UPDATE Agenda SET NumContato = @NumContato WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: sqlQuery, param: atualizarContato);
                return result;
            }
            //throw new System.NotImplementedException();
        }

        //DELETE FROM AGENDA
        public async Task<int> DeletarContatoAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string sqlQuery = @"DELETE FROM Agenda WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: sqlQuery, param: new { id });
                return result;
            }
            //throw new System.NotImplementedException();
        }   
    }
}
