using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHall.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Console { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateOnly? DataLancamento { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(5000)]
        public string Foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }


    }
}
