using System;
namespace BLL.Model
{
    public class Filho
    {
        public int Id { get; set; }
        public int IdPai { get; set; }
        public Pai Pai { get; set; }
        public Mae Mae { get; set; }
        public int IdMae { get; set; }
        public string Nome { get; set; }
        public string dtCadastro { get; set; }

        public Filho()
        {
        }
    }
}
