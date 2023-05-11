using System.Data.SqlClient;
using System.Data;
namespace Day2_KeepNote_Task
{
    public class Notes
    {
        public void Add_Notes()
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=ado_demos;Integrated Security = true");
            string query = "select * from Keep_Note";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            var row = ds.Tables[0].NewRow();

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;

            row["Title"] = title;
            row["Description"] = description;
            row["Date"] = date;


            ds.Tables[0].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Update(ds);
            Console.WriteLine("Notes Added sucessfully");
        }

        public void Get_Notes()
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=ado_demos;Integrated Security = true");
            Console.WriteLine("Enter Notes Id to get notes");
            int id = int.Parse(Console.ReadLine());
            string query = $"select * from Keep_Note where ID = {id}";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            Console.WriteLine("ID\tTitle\t\tDescription\t\tDate");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                }
                Console.WriteLine();
            }
        }

        public void Get_All_Notes()
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=ado_demos;Integrated Security = true");
            string query = $"select * from Keep_Note";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            Console.WriteLine("ID\tTitle\t\tDescription\t\tDate");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables[0].Rows[i][j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Total Notes = ");
            Console.Write($"{ds.Tables[0].Rows.Count}");
            Console.WriteLine();
        }

        public void Update_Notes()
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=ado_demos;Integrated Security = true");
            Console.WriteLine("Enter Notes Id to Update");
            int id = int.Parse(Console.ReadLine());
            string query = $"select * from Keep_Note where ID = {id}";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adp.Fill(ds);

            Console.Write("Enter Updated Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Updated Description: ");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;

            ds.Tables[0].Rows[0]["Title"] = title;
            ds.Tables[0].Rows[0]["Description"] = description;
            ds.Tables[0].Rows[0]["Date"] = date;


            SqlCommandBuilder builder = new SqlCommandBuilder(adp);

            adp.Update(ds);
            Console.WriteLine("Data updated sucessfully");
        }
        public void Delete_Notes()
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=ado_demos;Integrated Security = true");
            Console.WriteLine("Enter Notes Id to delete");
            int id = int.Parse(Console.ReadLine());
            string query = $"select * from Keep_Note where ID = {id}";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adp.Fill(ds);

            ds.Tables[0].Rows[0].Delete();

            SqlCommandBuilder builder = new SqlCommandBuilder(adp);

            adp.Update(ds);
            Console.WriteLine("Notes deleted sucessfully");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Notes notes = new Notes();

            while (true)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Add Notes");
                Console.WriteLine("2. Get Notes By Id");
                Console.WriteLine("3. Get All Notes");
                Console.WriteLine("4. Update Notes By Id");
                Console.WriteLine("5. Delete Notes By Id");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("---------------------------------------------------------");
                switch (choice)
                {
                    case 1:
                        {
                            notes.Add_Notes();
                            break;
                        }
                    case 2:
                        {
                            notes.Get_Notes();
                            break;
                        }
                    case 3:
                        {
                            notes.Get_All_Notes();
                            break;
                        }
                    case 4:
                        {
                            notes.Update_Notes();
                            break;
                        }
                    case 5:
                        {
                            notes.Delete_Notes();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
            }
        }
    }
}