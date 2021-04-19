
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

        public int CodigoBanco
		{
          get{return Codigo;}
          set{Codigo = value;}
        }
        
        public string NomeBanco
		{
          get{return Nome;}
          set{Nome = value;}
        }

        public override string ToString()
        {
            return this.Codigo + " - " + this.Nome;
        }

    }
}