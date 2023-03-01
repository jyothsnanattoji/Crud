using System;
using MySql.Data.MySqlClient;

namespace Student_Marks
{
    class Program
    {
        public static void Main()
        {
            MySqlConnection connection=Connection.ConnectionIntitation();
            try{
                connection.Open();
                Console.WriteLine("Connection successful! ");

                Console.WriteLine("1 -- STUDENT Table\n2 -- SCORECARD table  ");
                int choice=Convert.ToInt32(Console.ReadLine());

                Operation operation= new Operation();

                if(choice==1)
                {
                    operation.CRUDOperationOnStudent(connection);
                }
                else if(choice==2)
                {
                    operation.CRUDOperationOnScoreCard(connection);
                }
                else{
                        Console.WriteLine("Incorrect Choice! ");
                        connection.Close();
                        Environment.Exit(0);
                }
                
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
    }

}