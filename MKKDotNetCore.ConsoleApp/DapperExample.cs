using Dapper;
using MKKDotNetCore.ConsoleApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace MKKDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        private readonly string _connectionString = "Data Source=.; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123;";
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from Tbl_blog where DeleteFlag=0;";
                //var List<dynamic>? lst= db.Query(sql: query).ToList();
                //foreach(var dynamic item in lst){
                //    Console.WriteLine(item.BlogId);
                //    Console.WriteLine(item.BlogTitle);
                //    Console.WriteLine(item.BlogAuthor);
                //    Console.WriteLine(item.BlogContent);

                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (BlogDataModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);

                }
            }

            //DTO ==> Data Transfer Object

        }
        public void Create(string title, string author, string content)
        {
            string query = @"
            INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)
            ";

            using (IDbConnection db = new SqlConnection(_connectionString))

            {
                int result = db.Execute(sql: query, param: new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(value: result == 1 ? "saving successful" : "saving failed");
            }
        }

        public void Update(int id, string title, string author, string content)
        {
            string query = @"
            UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId
            ";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(sql: query, param: new BlogDataModel
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(value: result == 1 ? "update successful" : "update failed");
            }
        }

        public void Delete(int id)
        {
            string query = @"
            DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId
            ";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(sql: query, param: new BlogDataModel
                {
                    BlogId = id,
                });
                Console.WriteLine(value: result == 1 ? "Delete successful" : "Delete failed");
            }
        }
    }
}
