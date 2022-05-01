namespace Soitic.Models
{
    // [Table("directors")]
    public class Director
    {
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? Name { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; } = null!;
    }
}