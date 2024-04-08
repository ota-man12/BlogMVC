﻿using BlogMVC.Web.Data;
using BlogMVC.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext blogDbContext;

        public TagRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDbContext.Tags.AddAsync(tag);
            await blogDbContext.SaveChangesAsync();

            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var tag = await blogDbContext.Tags.FindAsync(id);
            if (tag != null)
            {
                blogDbContext.Tags.Remove(tag);
                await blogDbContext.SaveChangesAsync();

                //Show success notification
                return tag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var exisitingTag = await blogDbContext.Tags.FindAsync(tag.Id);

            if (exisitingTag != null)
            {
                exisitingTag.Name = tag.Name;
                exisitingTag.DisplayName = tag.DisplayName;
                //saving changes
                await blogDbContext.SaveChangesAsync();
                //Show success notification
                return exisitingTag;
            }
            else
            {
                return null;
            }
        }
    }
}

