using BlogMVC.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Web.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        //Creating BlogPost Base Table
        public DbSet<BlogPost> BlogPosts { get; set; }
        //Creating Tag Base Table
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }

    }
}

