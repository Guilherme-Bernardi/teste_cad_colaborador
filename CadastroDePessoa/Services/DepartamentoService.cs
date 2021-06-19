using CadastroDePessoa.Data;
using CadastroDePessoa.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDePessoa.Services
{
    public class DepartamentoService
    {
        private readonly CadastroDePessoaContext _context;

        public DepartamentoService(CadastroDePessoaContext context)
        {
            _context = context;
        }

        public async Task<List<Departamentos>> FindAllAsync()
        {
            return await _context.Departamentos.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
