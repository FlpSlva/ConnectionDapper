using System;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConnectionDapper
{
     class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";

            using(var connection = new SqlConnection(con.ConnectionString))
            {   
             // ListCategories(connection);
             // CreateCategory(connection);
              UpdateCategory(connection);
            }

        }

        static void ListCategories(SqlConnection connection)
        {
             var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
               foreach(var ca in categories)
               {
                Console.WriteLine($"{ca.Title} - {ca.Id}");
               }
        }

        static void CreateCategory(SqlConnection connection)
        {
              var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "categoria destinada a serviços do aws";
            category.Order = 8;
            category.Summary = "aws cloud";
            category.Featured = false;


            var insertSql = @"INSERT INTO
            [Category]
             VALUES(
                @ID,
                @Title,
                @Url,
                @Summary,
                @Order,
                @Description,
                @Featured)";

            var rows = connection.Execute(insertSql, new 
               {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
               });
               Console.WriteLine($"{rows} linhas inseridas");
            
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";

            var rows = connection.Execute(updateQuery, new {
                Title = "Front-End 2022",
                Id = "af3407aa-11ae-4621-a2ef-2028b85507c4"
                
            });
            Console.WriteLine("Campo Atualizado Com Sucesso!");

        }
    }
}