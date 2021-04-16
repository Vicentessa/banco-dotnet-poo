
namespace DIO.Bank
{
    public struct Banco
    {
        private int Codigo { get; set; }
        private string Nome { get; set; }

        public Banco(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }

        public override string ToString()
        {
            return this.Codigo + " - " + this.Nome;
        }

    }
}