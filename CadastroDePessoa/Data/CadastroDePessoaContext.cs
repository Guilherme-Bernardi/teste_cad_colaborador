using Microsoft.EntityFrameworkCore;
using CadastroDePessoa.Models;

namespace CadastroDePessoa.Data
{
    public class CadastroDePessoaContext : DbContext
    {
        public CadastroDePessoaContext(DbContextOptions<CadastroDePessoaContext> options)
            : base(options)
        {
        }

        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
    }
}
