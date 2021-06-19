using System;
using System.Collections.Generic;

namespace CadastroDePessoa.Models.ViewModels
{
    public class ColaboradorFormViewModel
    {
        public Colaborador Colaborador { get; set; }
        public ICollection<Departamentos> Departamentos { get; set; }
    }
}
