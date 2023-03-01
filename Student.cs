using MySql.Data.MySqlClient;
class Student
{
    public static Boolean CheckIfExistsSTUDENT(int id,MySqlConnection connection)
    {
        string query="SELECT 1 FROM STUDENT WHERE StudentId=@id";
        MySqlCommand command= new MySqlCommand(query,connection);
        command.Parameters.AddWithValue("@id",id);

        object result = command.ExecuteScalar();
        return result != null;
    }
    public static void InsertStudent(string firstName , string lastName,MySqlConnection connection)
    {
        string query="Insert into STUDENT(StudentFirstName, StudentLastName )values(@firstName,@lastName)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@firstName",firstName);
        command.Parameters.AddWithValue("@lastName",lastName);

        try{
            int rowsEffected=command.ExecuteNonQuery();
            Console.WriteLine(rowsEffected+" Rows Effected");
            Console.WriteLine("Inesrtion Successfull! ");
            Console.WriteLine("-------------------------------------------------");
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    public static void UpdateStudent(int id,string firstName,string lastName,MySqlConnection connection)
    {
        string query="UPDATE STUDENT set StudentFirstName=@firstName , StudentLastName=@lastName where StudentId=@id";
        MySqlCommand command= new MySqlCommand(query,connection);
        command.Parameters.AddWithValue("@firstName",firstName);
        command.Parameters.AddWithValue("@lastName",lastName);
        command.Parameters.AddWithValue("@id",id);

        try{
            int rowsEffected=command.ExecuteNonQuery();
            Console.WriteLine(rowsEffected+" Rows Effected");
            Console.WriteLine("Updated Successfully! ");
            Console.WriteLine("-------------------------------------------------");
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public static void DisplayStudent(MySqlConnection connection)
    {
        string query="Select * from STUDENT";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fName = reader.GetString(1);
                string lName = reader.GetString(2);

                Console.WriteLine("ID: {0}\nFirst Name: {1}\nLast Name: {2}\n\n", id, fName, lName);
            }
            Console.WriteLine("-------------------------------------------------");
            reader.Close();
    }
    public static void DeleteStudent(int id, MySqlConnection connection )
    {
        string query="Delete from STUDENT where StudentId=@id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id",id);
         try{
            int rowsEffected=command.ExecuteNonQuery();
            Console.WriteLine(rowsEffected+" Rows Effected");
            Console.WriteLine("Deleted Successfully! ");
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}