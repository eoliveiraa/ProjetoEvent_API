using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioID { get; set; }

        [Column(TypeName = "VARCHAR(70)")]
        [StringLength(50, ErrorMessage = "O título deve ter no máximo 70 caracteres.")]

        public string? TituloTipoUsuario { get; set; }
    }
}
