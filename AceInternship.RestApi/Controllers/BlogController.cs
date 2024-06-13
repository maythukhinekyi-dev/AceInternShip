using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AceInternship.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        public BlogController()
        {
            _connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "AceInternship",
                UserID = "sa",
                Password = "sa@123"
            };
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]";
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var lst = db.Query<TblBlog>(query).ToList();
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult CreatBlog()
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            return Ok("CreateBlog");
        }
        [HttpPut]
        public IActionResult PutBlog()
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            return Ok("PutBlog");
        }
        [HttpPatch]
        public IActionResult PatchBlog()
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            return Ok("PatchBlog");
        }
        [HttpDelete]
        public IActionResult DeleteBlog()
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            return Ok("DeleteBlog");
        }

    }

    public class TblBlog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}

