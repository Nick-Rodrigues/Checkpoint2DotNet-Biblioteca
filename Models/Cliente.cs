using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint2DotNet_Biblioteca.Models
{
    [Table("T_NET_Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Column("Email", TypeName = "varchar(255)")]
        [EmailAddress(ErrorMessage = "O email esta invalido")]
        public string Email { get; set; }

        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public string Cpf { get; set; }

        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
