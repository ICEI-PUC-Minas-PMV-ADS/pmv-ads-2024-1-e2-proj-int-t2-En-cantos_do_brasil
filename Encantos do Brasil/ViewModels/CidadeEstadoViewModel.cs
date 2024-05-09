using Encantos_do_Brasil.Models;
using System.Collections.Generic;

namespace Encantos_do_Brasil.ViewModels
{
    public class CidadeEstadoViewModel
    {
        public CidadeEstadoViewModel()
        {
            Cidades = new List<Cidade>();
            Estados = new List<Estado>();
        }

        public List<Cidade> Cidades { get; set; }

        public List<Estado> Estados { get; set; }
    }
}
