using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint2DotNet_Biblioteca.Models
{
    [Table("T_NET_Endereços")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnderecoId { get; set; }

        [Required]
        [StringLength(9)]
        public string CEP { get; set; }

        [Required]
        public int Numero { get; set; }

        public string Complemento { get; set; }
    }
}
