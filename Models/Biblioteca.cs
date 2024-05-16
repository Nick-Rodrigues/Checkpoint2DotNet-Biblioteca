using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint2DotNet_Biblioteca.Models
{
    [Table("T_NET_Bibliotecas")]
    public class Biblioteca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BibliotecaId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
    }
}
