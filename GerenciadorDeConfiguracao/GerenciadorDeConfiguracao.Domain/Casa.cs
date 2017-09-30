using System;

namespace GerenciadorDeConfiguracao.Domain
{
    public class Casa
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
