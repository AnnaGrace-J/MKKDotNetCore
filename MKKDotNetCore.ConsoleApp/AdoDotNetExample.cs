using System.Data;
using System.Data.SqlClient;

namespace MKKDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source=.; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123;";

        public void Read()
        {
            Console.WriteLine(value: "Connection String: " + _connectionString);

            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine(value: "Connection Opening");
            connection.Open();
            Console.WriteLine(value: "Connection Opened");

            string query = @"
SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0
";
            SqlCommand cmd = new SqlCommand(cmdText: query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dataTable: dt);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(value: reader[name: "BlogTitle"]);
                Console.WriteLine(value: reader[name: "BlogAuthor"]);
                Console.WriteLine(value: reader[name: "BlogId"]);
                Console.WriteLine(value: reader[name: "BlogContent"]);
                // Console.WriteLine(value: dr[columnName: "DeleteFlag"]);
            }


            Console.WriteLine(value: "Connection Closing");
            connection.Close();
            Console.WriteLine(value: "Connection Closed");

        }

        public void Create()
        {
            SqlConnection connection = new SqlConnection(connectionString: _connectionString);

            Console.WriteLine(value: "Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine(value: "Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine(value: "Blog Content: ");
            string content = Console.ReadLine();

            connection.Open();


            //Don't use this approach, it is vulnerable to SQL Injection attacks
            //string queryInsert = $@"
            //INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}',
            //            '{author}',
            //            '{content}',
            //            0)
            //";

            string query = $@"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle,
            @BlogAuthor,
            @BlogContent,
            0)
";

            SqlCommand cmd = new SqlCommand(cmdText: query, connection: connection);

            //added after parameterized query
            cmd.Parameters.AddWithValue(parameterName: "@BlogTitle", value: title);
            cmd.Parameters.AddWithValue(parameterName: "@BlogAuthor", value: author);
            cmd.Parameters.AddWithValue(parameterName: "@BlogContent", value: content);

            //This is for data read
            //SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd2);
            //DataTable dt = new DataTable();
            //adapter.Fill(dataTable: dt);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            //if(result == 1)
            //{
            //    Console.WriteLine(value: "Saving Successful");
            //}
            //else
            //{
            //    Console.WriteLine(value: "Saving Fail");
            //}

            Console.WriteLine(value: result == 1 ? "Saving Successful" : "Saving Fail");
        }

        public void Edit()
        {
            Console.Write(value: "Blog Id: ");
            string id = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString: _connectionString);
            connection.Open();

            string query = @"
SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId
            ";
            SqlCommand cmd = new SqlCommand(cmdText: query, connection);

            cmd.Parameters.AddWithValue(parameterName: "@BlogId", value: id);

            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dataTable: dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine(value: "No Data Found");
                return;
            }
            DataRow dr = dt.Rows[index: 0];
            Console.WriteLine(value: dr[columnName: "BlogId"]);
            Console.WriteLine(value: dr[columnName: "BlogTitle"]);
            Console.WriteLine(value: dr[columnName: "BlogAuthor"]);
            Console.WriteLine(value: dr[columnName: "BlogContent"]);
            //Console.WriteLine(value: dr[columnName: "DeleteFlag"]);

        }
        public void Update()
        {
            Console.WriteLine(value: "Blog Id: ");
            string id = Console.ReadLine();

            Console.WriteLine(value: "Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine(value: "Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine(value: "Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(connectionString: _connectionString);

            connection.Open();

            string query = $@"
UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId
";

            SqlCommand cmd = new SqlCommand(cmdText: query, connection: connection);

            //added after parameterized query
            cmd.Parameters.AddWithValue(parameterName: "@BlogId", value: id);
            cmd.Parameters.AddWithValue(parameterName: "@BlogTitle", value: title);
            cmd.Parameters.AddWithValue(parameterName: "@BlogAuthor", value: author);
            cmd.Parameters.AddWithValue(parameterName: "@BlogContent", value: content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(value: result == 1 ? "Updating Successful" : "Updating Fail");
        }

        public void Delete()
        {
            SqlConnection connection = new SqlConnection(connectionString: _connectionString);

            connection.Open();
            Console.WriteLine(value: "Blog Id: ");
            string id = Console.ReadLine();
            string query = $@"
            DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId
";
            SqlCommand cmd = new SqlCommand(cmdText: query, connection: connection);
            cmd.Parameters.AddWithValue(parameterName: "@BlogId", value: id);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(value: result == 1 ? "Deleting Successful" : "Deleting Fail");
        }
    }
}
