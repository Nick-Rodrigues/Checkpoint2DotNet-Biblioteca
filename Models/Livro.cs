using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint2DotNet_Biblioteca.Models
{
    [Table("T_NET_Livros")]
    public class Livro
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Gênero é obrigatório")]
        public string Genero { get; set; }

        public DateTime DataLancamento { get; set; }

        public ICollection<Autor>? Autores { get; set; }
    }
}
