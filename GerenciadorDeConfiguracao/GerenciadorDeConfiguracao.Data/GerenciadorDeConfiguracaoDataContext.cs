using GerenciadorDeConfiguracao.Domain;
using System.Data.Entity;

namespace GerenciadorDeConfiguracao.Data
{
    public class GerenciadorDeConfiguracaoDataContext : DbContext
    {
        public GerenciadorDeConfiguracaoDataContext() : base("GerenciadorDeConfiguracaoConnectionString")
        {
            //Database.SetInitializer<GerenciadorDeConfiguracaoDataContext>(new GerenciadorDeConfiguracaoDataContextInitializer());
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Casa> Casas { get; set; }

        public DbSet<Funcao> Funcoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CasaMap());
            modelBuilder.Configurations.Add(new FuncaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class GerenciadorDeConfiguracaoDataContextInitializer : DropCreateDatabaseIfModelChanges<GerenciadorDeConfiguracaoDataContext>
    {
        protected override void Seed(GerenciadorDeConfiguracaoDataContext context)
        {
            context.Casas.Add(new Casa { Id = 1, Nome = "Casa de Praia" });
            context.Casas.Add(new Casa { Id = 2, Nome = "Casa de Campo" });
            context.Casas.Add(new Casa { Id = 3, Nome = "Casa de Trabalho" });
            context.SaveChanges();

            context.Funcoes.Add(new Funcao { Id = 1, CasaId = 1, LuzSala = true, VentiladorSala = 75 });
            context.Funcoes.Add(new Funcao { Id = 2, CasaId = 2, LuzQuarto = true, VentiladorQuarto= 55 });
            context.Funcoes.Add(new Funcao { Id = 1, CasaId = 1, LuzBanheiro = true, LuzQuarto=true, LuzCozinha=true });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
