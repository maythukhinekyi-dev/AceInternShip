using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AceInternship.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            return Ok("GetBlogs");
        }
        [HttpPost]
        public IActionResult CreateBlog()
        {
            return Ok("CreateBlog");
        }
        [HttpPut]
        public IActionResult UpdateBlog()
        {
            return Ok("UpdateBlog");
        }
        [HttpPatch]
        public IActionResult PatchBlog()
        {
            return Ok("PatchBlog");
        }
        [HttpDelete]
        public IActionResult DeleteBlog()
        {
            return Ok("DeleteBlog");
        }

    }
}
