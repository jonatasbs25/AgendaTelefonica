using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AgendaTelefonica.API.Data
{
    //implementação da interface IDisposable
    //permite que o Garbage Colletor libere objetos da memória após seu uso
    public class Banco : IDisposable
    {
        //váriavel de leitura que gerenciará a conexão com o banco
        //public readonly IDbConnection Connection;
        public IDbConnection Connection { get; }

        //ao iniciar o objeto Banco, receberá como parâmetro as informações
        //contidas no arquivo de configuração da aplicação e abrirá a conexão
        public Banco(IConfiguration configuration)
        {
            //a váriavel abre a conexão pegando as informações do banco que estão
            //no arquivo appsettings.json
            Connection = new SqlConnection(configuration
                .GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        //o método Dispose() fechará a conexão após seu uso e liberará
        //o espaço alocado na memória 
        public void Dispose() 
        {
            if (Connection.State == ConnectionState.Open)
            Connection.Close();
            //Connection?.Dispose();
        } 
    }
}
