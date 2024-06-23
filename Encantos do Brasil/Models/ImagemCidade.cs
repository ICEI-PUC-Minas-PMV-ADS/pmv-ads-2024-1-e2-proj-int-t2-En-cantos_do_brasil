using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Encantos_do_Brasil.Models
{
    [Table("ImagensCidades")]
    public class ImagemCidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Dados { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string TipoConteudo { get; set; }

        [Required]
        public TipoImagem TipoImagem { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Escolha uma cidade!")]
        [ForeignKey("Cidade")]
        public int IdCidade { get; set; }

        public Cidade Cidade { get; set; }
    }

    public enum TipoImagem
    {
        Principal,
        Banner,
        Rodape,
        Img1,
        Img2,
        Img3,
        Img4,
        Img5,
        Img6
    }
}
