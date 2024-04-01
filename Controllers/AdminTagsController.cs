using BlogMVC.Web.Models.Domain;
using BlogMVC.Web.Models.ViewModels;
using BlogMVC.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        //Constructor Injection
        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        //Show Data from DB
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //Used DbContext to read the tags
            var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);
            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null)
            {
                // Success
            }
            else
            {
                // Error
            }
            //Show error notification
            return RedirectToAction("List");
        }

        //Delete
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                //Show success notification
                return RedirectToAction("List");
            }
            //How an error notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        //Back to list
        public IActionResult Back()
        {
            return RedirectToAction("List");
        }

    }
}

