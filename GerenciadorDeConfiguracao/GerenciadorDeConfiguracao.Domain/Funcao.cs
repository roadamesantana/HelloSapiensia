namespace GerenciadorDeConfiguracao.Domain
{
    public class Funcao
    {
        public int Id { get; set; }
        
        public bool LuzSala { get; set; }

        public bool LuzQuarto { get; set; }

        public bool LuzBanheiro { get; set; }

        public bool LuzCozinha { get; set; }

        public int VentiladorSala { get; set; }

        public int VentiladorQuarto { get; set; }

        public int CasaId { get; set; }

        public virtual Casa Casa { get; set; }

        public override string ToString()
        {
            return string.Concat( "Funções da casa ", this.Casa.Nome);
        }
    }
}