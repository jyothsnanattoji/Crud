using MySql.Data.MySqlClient;

class ScoreCard
{
    public static Boolean CheckIfExistsSCORECARD(int id,MySqlConnection connection)
    {
        string query="SELECT 1 FROM SCORECARD WHERE StudentId=@id";
        MySqlCommand command= new MySqlCommand(query,connection);
        command.Parameters.AddWithValue("@id",id);

        object result = command.ExecuteScalar();
        return result != null;
    }
    public static void InsertMarks(int id,List<int> marks ,MySqlConnection connection)
    {
        string query = "INSERT INTO SCORECARD (StudentId, Subject1, Subject2, Subject3, Subject4) VALUES (@id, @subject1, @subject2, @subject3, @subject4)";
         MySqlCommand command = new MySqlCommand(query, connection);
         command.Parameters.AddWithValue("@id", id);
         command.Parameters.AddWithValue("@subject1", marks.ElementAt(0));
         command.Parameters.AddWithValue("@subject2", marks.ElementAt(1));
         command.Parameters.AddWithValue("@subject3", marks.ElementAt(2));
         command.Parameters.AddWithValue("@subject4", marks.ElementAt(3));
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

    public static void UpdateScoreCardAll(int id,List<int> marks, MySqlConnection connection)
    {
        string query="UPDATE SCORECARD set Subject1=@subject1,Subject2=@subject2, Subject3=@subject3,Subject4=@subject4 where StudentId=@id";
        MySqlCommand command= new MySqlCommand(query,connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@subject1", marks.ElementAt(0));
        command.Parameters.AddWithValue("@subject2", marks.ElementAt(1));
        command.Parameters.AddWithValue("@subject4", marks.ElementAt(2));
        command.Parameters.AddWithValue("@subject3", marks.ElementAt(3));

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

    public static void DeleteScoredCard(int id,MySqlConnection connection)
    {
        string query="Delete from SCORECARD where StudentId=@id";
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

    public static void UpdateScoreCardIndividual(int id,int SubjectId,int newMarks, MySqlConnection connection)
    {
        String SubjectNumber="Subject"+SubjectId;
        string query=$"UPDATE SCORECARD set {SubjectNumber}=@newMarks where StudentId=@id";
        MySqlCommand command= new MySqlCommand(query,connection);
        command.Parameters.AddWithValue("@newMarks",newMarks);
        command.Parameters.AddWithValue("@id",id);
         try{
            int rowsEffected=command.ExecuteNonQuery();
            Console.WriteLine(rowsEffected+" Rows Effected");
            Console.WriteLine("Updated Successfully! ");
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public static void DisplayScoreCard(MySqlConnection connection)
    {
        string query="SELECT STUDENT.StudentId,StudentFirstName,StudentLastName,Subject1,Subject2,Subject3,Subject4,Total FROM STUDENT INNER JOIN SCORECARD ON STUDENT.StudentId=SCORECARD.StudentId";
        MySqlCommand command = new MySqlCommand(query,connection);
        MySqlDataReader reader= command.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string fName = reader.GetString(1);
            string lName = reader.GetString(2);
            string subject1= reader.GetString(3);
            string subject2= reader.GetString(4);
            string subject3= reader.GetString(5);
            string subject4= reader.GetString(6);
            string total =reader.GetString(7);

            Console.WriteLine("\nID: {0}\nFirst Name:{1}  Second Name: {2} \nSubject1: {3}    Subject2: {4}   Subject3: {5}   Subject4:{6}  Total:{7}\n\n",id,fName,lName,subject1,subject2,subject3,subject4,total);
        }
        reader.Close();
    }
}