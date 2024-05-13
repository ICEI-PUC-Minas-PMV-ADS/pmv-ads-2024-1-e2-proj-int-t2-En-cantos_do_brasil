using Encantos_do_Brasil.Models;
using System.Collections.Generic;

namespace Encantos_do_Brasil.ViewModels
{
    public class CidadeEstadoViewModel 
    {
        public CidadeEstadoViewModel()
        {
            ImagemEstados = new List<ImagemEstado>();
            ImagemCidades = new List<ImagemCidade>();
        }

        public List<ImagemEstado> ImagemEstados { get; set; }
        public List<ImagemCidade> ImagemCidades { get; set; }
    }
}
