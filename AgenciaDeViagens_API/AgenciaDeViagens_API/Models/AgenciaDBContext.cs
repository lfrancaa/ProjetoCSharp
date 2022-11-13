using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens_API.Models
{
    public class AgenciaDBContext : DbContext
    {
        public AgenciaDBContext(DbContextOptions<AgenciaDBContext> options)
          : base(options)
        { }
        public DbSet<Passageiro> Passageiro { get; set; }
        public DbSet<Passagem> Passagem { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Voo> Voo { get; set; }
    }
}