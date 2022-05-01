namespace Soitic.Models
{
    // [Table("movies")]
    public class Movie
    {
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? Name { get; set; }
        // public uint? Director_id { get; set; }
        public Nullable<uint> Director_id { get; set; }
        
        [ForeignKey("Director_id")]
        public virtual Director? Director { get; set; } = null!;
    }
}