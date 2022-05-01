using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Soitic.Models;

namespace Soitic.Models
{
    public class SoiticContext : DbContext
    {
        public SoiticContext(DbContextOptions<SoiticContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = null!;

        public DbSet<Soitic.Models.Director> Director { get; set; } = null!;
    }
}