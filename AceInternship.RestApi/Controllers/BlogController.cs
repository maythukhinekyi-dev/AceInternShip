using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

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
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var lst = db.Query<TblBlog>(Queries.BlogList).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            var item = db.Query<TblBlog>(Queries.BlogById, new { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreatBlog(TblBlog blog)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            int result = db.Execute(Queries.BlogCreate, blog);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult PutBlog(int id, TblBlog blog)
        {
            blog.BlogId = id;
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            int result = db.Execute(Queries.BlogUpdate, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }
        [HttpPatch]
        public IActionResult PatchBlog()
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            return Ok("PatchBlog");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
            int result = db.Execute(Queries.BlogDelete, new {BlogId=id});
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }

    }

    public class TblBlog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }

    public static class Queries
    {
        public static string BlogList { get; }= @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]";

        public static string BlogById { get; } = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]
  WHERE [BlogId]=@BlogId";

        public static string BlogCreate { get; } = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        public static string BlogDelete { get; } = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE [BlogId]=@BlogId";

        public static string BlogUpdate { get; } = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] =@BlogContent
 WHERE [BlogId]=@BlogId";
    }
}

