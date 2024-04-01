using BlogMVC.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Web.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }

        //Creating BlogPost Base Table
        public DbSet<BlogPost> BlogPosts { get; set; }
        //Creating Tag Base Table
        public DbSet<Tag> Tags { get; set; }

    }
}

