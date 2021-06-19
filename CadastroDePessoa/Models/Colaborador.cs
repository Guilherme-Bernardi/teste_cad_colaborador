using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDePessoa.Models
{
    public class Colaborador
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho do {0} deve ser entre {2} e {1}")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Tamanho do {0} deve ser entre {2} e {1}")]
        public String CPF { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Salario { get; set; }
        public Departamentos Departamento { get; set; }
        [Display(Name = "Departamento")]
        public int DepartamentosId { get; set; }

        public Colaborador()
        {
        }

        public Colaborador(int id, string nome, string cPF, double salario, Departamentos departamento)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Salario = salario;
            Departamento = departamento;
        }
    }
}
