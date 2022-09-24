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
              ListCategories(connection);
              CreateManyCategory(connection);
             // CreateCategory(connection);
             // UpdateCategory(connection);
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


        static void CreateManyCategory(SqlConnection connection)
        {

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria Nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;


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

            var rows = connection.Execute(insertSql, new[]{
                new{
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured  
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
                    
                   
            });
               Console.WriteLine($"{rows} linhas inseridas");
            
        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            
        }
    }
}