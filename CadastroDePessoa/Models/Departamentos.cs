using System.Collections.Generic;

namespace CadastroDePessoa.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();

        public Departamentos()
        {
        }

        public Departamentos(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddColaborador(Colaborador colaborador)
        {
            Colaboradores.Add(colaborador);
        }
    }
}
