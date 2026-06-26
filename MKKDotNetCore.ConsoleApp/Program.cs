//See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadKey();

//md => Markdown


string connectionString = "Data Source=.; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123;";
Console.WriteLine(value: "Connection String: " + connectionString);

SqlConnection connection = new SqlConnection(connectionString);

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
SqlCommand cmd = new SqlCommand(cmdText: query,connection);
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

//Data Set
//Data Table
//Data Row
//Data Column

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(value: dr[columnName: "BlogId"]);
//    Console.WriteLine(value: dr[columnName: "BlogTitle"]);
//    Console.WriteLine(value: dr[columnName: "BlogAuthor"]);
//    Console.WriteLine(value: dr[columnName: "BlogContent"]);
//    // Console.WriteLine(value: dr[columnName: "DeleteFlag"]);

//}