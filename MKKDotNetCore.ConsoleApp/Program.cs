//See https://aka.ms/new-console-template for more information
using MKKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadKey();

//md => Markdown


//string connectionString = "Data Source=.; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123;";
//Console.WriteLine(value: "Connection String: " + connectionString);

//SqlConnection connection = new SqlConnection(connectionString);

//Console.WriteLine(value: "Connection Opening");
//connection.Open();
//Console.WriteLine(value: "Connection Opened");

//string query = @"
//SELECT [BlogId]
//      ,[BlogTitle]
//      ,[BlogAuthor]
//      ,[BlogContent]
//      ,[DeleteFlag]
//  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0
//";
//SqlCommand cmd = new SqlCommand(cmdText: query,connection);
////SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd);
////DataTable dt = new DataTable();
////adapter.Fill(dataTable: dt);

//SqlDataReader reader = cmd.ExecuteReader();
//while (reader.Read())
//{
//    Console.WriteLine(value: reader[name: "BlogTitle"]);
//    Console.WriteLine(value: reader[name: "BlogAuthor"]);
//    Console.WriteLine(value: reader[name: "BlogId"]);
//    Console.WriteLine(value: reader[name: "BlogContent"]);
//    // Console.WriteLine(value: dr[columnName: "DeleteFlag"]);
//}


//Console.WriteLine(value: "Connection Closing");
//connection.Close();
//Console.WriteLine(value: "Connection Closed");

////Data Set
////Data Table
////Data Row
////Data Column

////foreach (DataRow dr in dt.Rows)
////{
////    Console.WriteLine(value: dr[columnName: "BlogId"]);
////    Console.WriteLine(value: dr[columnName: "BlogTitle"]);
////    Console.WriteLine(value: dr[columnName: "BlogAuthor"]);
////    Console.WriteLine(value: dr[columnName: "BlogContent"]);
////    // Console.WriteLine(value: dr[columnName: "DeleteFlag"]);

////}
//string connectionString2 = "Data Source = .; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123";
//SqlConnection connection2 = new SqlConnection(connectionString: connectionString2);

//Console.WriteLine(value: "Blog Title: ");
//string title = Console.ReadLine();

//Console.WriteLine(value: "Blog Author: ");
//string author = Console.ReadLine();

//Console.WriteLine(value: "Blog Content: ");
//string content = Console.ReadLine();

//connection2.Open();


////Don't use this approach, it is vulnerable to SQL Injection attacks
////string queryInsert = $@"
////INSERT INTO [dbo].[Tbl_Blog]
////           ([BlogTitle]
////           ,[BlogAuthor]
////           ,[BlogContent]
////           ,[DeleteFlag])
////     VALUES
////           ('{title}',
////            '{author}',
////            '{content}',
////            0)
////";

//string queryInsert = $@"
//INSERT INTO [dbo].[Tbl_Blog]
//           ([BlogTitle]
//           ,[BlogAuthor]
//           ,[BlogContent]
//           ,[DeleteFlag])
//     VALUES
//           ('@BlogTitle',
//            '@BlogAuthor',
//            '@BlogContent',
//            0)
//";

//SqlCommand cmd2 = new SqlCommand(cmdText: queryInsert, connection: connection2);

////added after parameterized query
//cmd2.Parameters.AddWithValue(parameterName: "@BlogTitle", value: title);
//cmd2.Parameters.AddWithValue(parameterName: "@BlogAuthor", value: author);
//cmd2.Parameters.AddWithValue(parameterName: "@BlogContent", value: content);

////This is for data read
////SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd2);
////DataTable dt = new DataTable();
////adapter.Fill(dataTable: dt);

//int result = cmd2.ExecuteNonQuery();

//connection2.Close();

////if(result == 1)
////{
////    Console.WriteLine(value: "Saving Successful");
////}
////else
////{
////    Console.WriteLine(value: "Saving Fail");
////}

//Console.WriteLine(value: result == 1 ? "Saving Successful" : "Saving Fail");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();
DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create(title: "dfasdf", author: "dfasdf",content: "dfasdf");
//dapperExample.Update(id:1004 , title: "Rarr", author: "Garrr", content: "Marrr");
//dapperExample.Delete(id: 1005);
dapperExample.Edit(1);
dapperExample.Edit(1009);

Console.ReadKey();