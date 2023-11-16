using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.View.Class
{
    public partial class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public void insertCategory(Category category)
        {
            Categories.Add(category);
            SaveChanges();
        }

        public void deleteCategory(Category category)
        {
            Categories.Remove(category);
            SaveChanges();
        }

        public void updateCategory(int index)
        {
            List<Category> categories = Categories.ToList();
            Categories.Update(categories[index - 1]);
            SaveChanges();
        }

        public List<Category> getCategories()
        {
            return Categories.ToList();
        }

        public void insertBook(Book book)
        {
            Books.Add(book);
            SaveChanges();
        }

        public void deleteBook(Book book)
        {
            Books.Remove(book);
            SaveChanges();
        }

        public void updateBook(Book book)
        {
            Books.Update(book);
            SaveChanges();
        }

        public List<Book> getAllBooks()
        {
            List<Book> books;

            books = Books.ToList();

            return books;
        }
        public Book GetBook(int id)
        {
            return Books.First(c => c.ID == id );
        }

        public void updateQuantityBook(int id,string quantity)
        {
            Books.First(c=>c.ID==id).Quantity = quantity;
            SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var secret = new ConfigurationBuilder().AddUserSecrets<DBContext>().Build();
            var connectionString = secret.GetSection("MyDB:ConnectionString").Value;
            connectionString = connectionString.Replace("@Catalog", "BookStore");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryID).HasColumnName("id");
                entity.Property(e => e.CategoryName).HasColumnName("type");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.ID).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Image).HasColumnName("image");
                entity.Property(e => e.Publish).HasColumnName("publish");
                entity.Property(e => e.Author).HasColumnName("author");
                entity.Property(e => e.CategoryID).HasColumnName("categoryid");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.RawPrice).HasColumnName("rawprice");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Category).WithMany(p => p.Books).HasForeignKey(d => d.CategoryID).HasConstraintName("FK_Book_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
