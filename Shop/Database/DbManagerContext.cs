using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Book;
using Shop.Core;
using Shop.People;
using Shop.Users;

namespace Shop.Database
{
    internal class DbManagerContext : DbContext
    {
        /* public virtual DbSet<EBook> Books { get; set; }
         public virtual DbSet<PapperBook> PapperBooks { get; set; }
         public virtual DbSet<Author> Authors { get; set; }
         public virtual DbSet<Publisher> Publishers { get; set; }
         public virtual DbSet<Translator> Translators { get; set; 
        public virtual DbSet<Tag> Tags { get; set; }*/
        public virtual DbSet<User> Users { get; set; }


        public DbManagerContext() 
            : base("name=ShopDBEntities")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", "M:\\Programowanie\\C#\\Becoming a software developer\\Shop\\Shop\\Database");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region User

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<User>()
                .Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<User>()
                .Property(u => u.IsValid)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles);

            



            #endregion





            /*
            modelBuilder.Entity<BookBase>()
                .HasKey(b => b.BookId);

            modelBuilder.Entity<BookBase>()
                .Property(b => b.Guid)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.OriginalTitle)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.Isbn)
                .HasMaxLength(13)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.NumberOfPages)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.DatePublished)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.Subject)
                .IsRequired();

            modelBuilder.Entity<BookBase>()
                .Property(b => b.Language)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasKey(p => p.PersonId);

*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
