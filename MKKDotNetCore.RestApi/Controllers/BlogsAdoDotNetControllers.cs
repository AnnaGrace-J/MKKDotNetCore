using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MKKDotNetCore.Database.Models;
using MKKDotNetCore.RestApi.ViewModels;
using System.Reflection.Metadata;

namespace MKKDotNetCore.RestApi.Controllers
{
    public class BlogsAdoDotNetControllers : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123;  TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetBlogs()
            
        {
            List<BlogViewModel> lst = new List<BlogViewModel>();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0
";
            SqlCommand cmd = new SqlCommand(cmdText: query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(value: reader[name: "BlogId"]);
                Console.WriteLine(value: reader[name: "BlogTitle"]);
                Console.WriteLine(value: reader[name: "BlogAuthor"]);
                Console.WriteLine(value: reader[name: "BlogContent"]);
                //lst.Add(new BlogViewModel
                //{
                //    Id = Convert.ToInt32(reader["BlogId"]),
                //    Title = Convert.ToString(reader["BlogTitle"]),
                //    Author = Convert.ToString(reader["BlogAuthor"]),
                //    Content = Convert.ToString(reader["BlogContent"]),
                //    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                //});
                var item = new BlogViewModel
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                };
                lst.Add(item);
            }
            connection.Close();
            return Ok(lst);
        }


        //[HttpGet("{id}")]
        //public IActionResult GetBlog(int id)
        //{
            
        //}

        //[HttpPost]
        //public IActionResult CreateBlogs(TblBlog blog)
        //{
            
        //}
        //[HttpPut("{id}")]
        //public IActionResult UpdateBlogs(int id, TblBlog blog)
        //{
            
        //}
        [HttpPatch("{id}")]
        public IActionResult PatchBlogs(int id, BlogViewModel blog)
        {
            string conditions = "";
            if (!string.IsNullOrEmpty(blog.Title))
            {
                conditions += " BlogTitle = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                conditions += " BlogAuthor = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                conditions += " BlogContent = @BlogContent, ";
            }
            if (conditions.Length == 0)
            {
                return BadRequest("Invalid Parameters");
            }
            conditions = conditions.Substring(0,conditions.Length - 2);
            SqlConnection connection = new SqlConnection(connectionString: _connectionString);

            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId
";

            SqlCommand cmd = new SqlCommand(cmdText: query, connection: connection);

            //added after parameterized query
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.Title))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            }
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return Ok(result>0? "Updating Successful." : "Updating Fail");
        }
        //[HttpDelete("{id}")]
        //public IActionResult DeleteBlogs(int id)
        //{

            


        //}
    }
}
