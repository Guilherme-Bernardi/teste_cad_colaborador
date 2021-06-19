using CadastroDePessoa.Data;
using CadastroDePessoa.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDePessoa.Services.Exceptions;

namespace CadastroDePessoa.Services
{
    public class ColaboradorService
    {
        private readonly CadastroDePessoaContext _context;

        public ColaboradorService(CadastroDePessoaContext context)
        {
            _context = context;
        }

        public async Task<List<Colaborador>> FindAllAsync()
        {
            return await _context.Colaborador.ToListAsync();
        }

        public async Task Insert(Colaborador obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Colaborador> FindByIdAsync(int id)
        {
            return await _context.Colaborador.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Colaborador obj)
        {
            bool hasAny = await _context.Colaborador.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}



