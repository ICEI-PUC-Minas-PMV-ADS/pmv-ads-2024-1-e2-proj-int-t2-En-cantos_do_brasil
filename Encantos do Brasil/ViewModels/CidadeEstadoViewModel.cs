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
            Cidade = new List<Cidade>();
            Estado = new List<Estado>();
            PontoTuristico = new List<PontoTuristico>();
            Hotel =new List<Hotel>();
            TextoEstado = new List<TextoEstado>();
            TextoCidade = new List<TextoCidade>();
        }

        public List<ImagemEstado> ImagemEstados { get; set; }
        public List<ImagemCidade> ImagemCidades { get; set; }
        public List<Cidade> Cidade { get; set; }
        public List<Estado> Estado { get; set; }
        public List<PontoTuristico> PontoTuristico { get; set; }
        public List<Hotel> Hotel { get; set; }
        public List<TextoEstado> TextoEstado { get; set; }
        public List<TextoCidade> TextoCidade { get; set; }
    }
}
