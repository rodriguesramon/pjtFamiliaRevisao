using System;
using BLL.Model;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace DAL.Persistence
{
    public class PaiDal : Conexao
    {

        public void Salvar(Pai pai){
            try{
                var sql = "INSERT INTO pai(nome, dtCadastro) " +
                    "VALUES(@nome, CURDATE())";
                
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", pai.Nome);
                command.ExecuteNonQuery();
            }catch(Exception erro){
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public Pai PesquisarPorId(int id){
            try{
                var sql = "SELECT * FROM pai WHERE id = @id";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();

                Pai pai = new Pai();

                if(dataReader.Read()){
                    pai.Id = Convert.ToInt32(dataReader["id"]);
                    pai.Nome = dataReader["nome"].ToString();
                    pai.dtCadastro = dataReader["dtCadastro"].ToString();
                }
                return pai;
            }catch (Exception erro){
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public List<Pai> PesquisarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM pai WHERE nome LIKE '%" + nome + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Pai> listaPai = new List<Pai>();

                while (dataReader.Read())
                {
                    Pai pai = new Pai();
                    pai.Id          =  Convert.ToInt32(dataReader["id"]);
                    pai.Nome        =  dataReader["nome"].ToString();
                    pai.dtCadastro  =  dataReader["dtCadastro"].ToString();

                    listaPai.Add(pai);
                }
                return listaPai;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro);
            }
        }

        public PaiDal()
        {
        }
    }
}
