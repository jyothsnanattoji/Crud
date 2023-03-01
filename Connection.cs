using MySql.Data.MySqlClient;
using System;
class Connection
{
    public static MySqlConnection ConnectionIntitation()
    {
        string connectionString ="server=localhost;user=root;password=password;database=STUDENT_MARKS";
        MySqlConnection connection= new MySqlConnection(connectionString);
        return connection;
    }
}