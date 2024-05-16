using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint2DotNet_Biblioteca.Models
{
    [Table("T_NET_Autores")]
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        public ICollection<Livro>? Livros { get; set; }
    }
}
