using System;
using BLL.Model;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace DAL.Persistence
{
    public class FilhoDal : Conexao
    {

        public void Salvar(Filho filho)
        {
            try
            {
                var sql = "INSERT INTO filho(nome, dtCadastro) " +
                    "VALUES(@nome, CURDATE())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", filho.Nome);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public Filho PesquisarPorId(int id)
        {
            try
            {
                var sql = "SELECT * FROM filho WHERE id = @id";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();

                Filho filho = new Filho();

                if (dataReader.Read())
                {
                    filho.Id = Convert.ToInt32(dataReader["id"]);
                    filho.Nome = dataReader["nome"].ToString();
                    filho.dtCadastro = dataReader["dtCadastro"].ToString();
                }
                return filho;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public List<Filho> PesquisarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM filho WHERE nome LIKE '%" + nome + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Filho> listaFilho = new List<Filho>();

                while (dataReader.Read())
                {
                    Filho filho = new Filho();
                    filho.Id = Convert.ToInt32(dataReader["id"]);
                    filho.Nome = dataReader["nome"].ToString();
                    filho.dtCadastro = dataReader["dtCadastro"].ToString();

                    listaFilho.Add(filho);
                }
                return listaFilho;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public FilhoDal()
        {
        }
    }
}
