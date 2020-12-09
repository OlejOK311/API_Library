using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace EFData
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }

		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>()
				.HasOne(p => p.Author)
				.WithMany(t => t.Books)
				.HasForeignKey(p => p.AuthorId);

			modelBuilder.Entity<Author>()
				.HasMany(p => p.Books)
				.WithOne(t => t.Author)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
