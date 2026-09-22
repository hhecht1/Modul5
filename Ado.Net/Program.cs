using Microsoft.Data.SqlClient;

namespace Ado.Net
{
    class Program
    {

        const string ConnectionString = "Server=TESTVM\\SQLEXPRESS;Database=SchulbibliothekContext;Trusted_Connection=True;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            var buch = new Buch
            {
                Titel = "c# ist besser als Java." + Guid.NewGuid().ToString()
            };
            Insert(buch);

            // Update(buch);

            // Delete(buch);

        }

        static void Insert(Buch buch)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            var sqlQuery = "INSERT INTO Buch SELECT( @Titel)";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Titel", buch.Titel);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine($"Inserted book with title: {buch.Titel}");

        }



        static void Delete(Buch buch)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            var sqlQuery = "DELETE FROM Buch WHERE Titel = @Titel";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Titel", buch.Titel);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine($"Deleted book with title: {buch.Titel}");
        }

        static void Update(Buch buch)
        {
            var oldTitle = buch.Titel;
            buch.Titel = "JAVA ist immer noch besser als C#." + Guid.NewGuid();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            var sqlQuery = "UPDATE Buch SET Titel = @Titel WHERE Titel = @OldTitel";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Titel", buch.Titel);
            sqlCommand.Parameters.AddWithValue("@OldTitel", oldTitle);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine($"Updated book from title: {oldTitle} to new title: {buch.Titel}");
        }




    }
}