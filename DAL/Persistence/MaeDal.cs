using System;
using BLL.Model;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace DAL.Persistence
{
    public class MaeDal : Conexao
    {

        public void Salvar(Mae mae)
        {
            try
            {
                var sql = "INSERT INTO mae(nome, dtCadastro) " +
                    "VALUES(@nome, CURDATE())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", mae.Nome);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public Mae PesquisarPorId(int id)
        {
            try
            {
                var sql = "SELECT * FROM mae WHERE id = @id";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();

                Mae mae = new Mae();

                if (dataReader.Read())
                {
                    mae.Id = Convert.ToInt32(dataReader["id"]);
                    mae.Nome = dataReader["nome"].ToString();
                    mae.dtCadastro = dataReader["dtCadastro"].ToString();
                }
                return mae;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public List<Mae> PesquisarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM mae WHERE nome LIKE '%" + nome + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Mae> listaMae = new List<Mae>();

                while (dataReader.Read())
                {
                    Mae mae = new Mae();
                    mae.Id = Convert.ToInt32(dataReader["id"]);
                    mae.Nome = dataReader["nome"].ToString();
                    mae.dtCadastro = dataReader["dtCadastro"].ToString();

                    listaMae.Add(mae);
                }
                return listaMae;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public MaeDal()
        {
        }
    }
}
