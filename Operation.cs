using MySql.Data.MySqlClient;
class Operation
{
    public void CRUDOperationOnStudent(MySqlConnection connection)
    {
        while(true)
                    {
                        Console.WriteLine("Select 1 to Insert : ");
                        Console.WriteLine("Select 2 to Update : ");
                        Console.WriteLine("Select 3 to Delete : ");
                        Console.WriteLine("Select 4 to Display : ");
                        Console.WriteLine("Select 5 to Exit: ");
                        int input=Convert.ToInt32(Console.ReadLine());
                        int id;
                        bool comp;
                        String fname,lname;
                        switch(input)
                        {
                            case 1:
                                Console.WriteLine("Enter the first Name: ");
                                fname=Console.ReadLine() ?? "First Name Required!!!";
                                Console.WriteLine("Enter the last Name: ");
                                lname=Console.ReadLine() ?? "";
                                Student.InsertStudent(fname,lname,connection);
                                break;
                            case 2:
                                Console.WriteLine("Enter the student id to be updated: ");
                                id=Convert.ToInt32(Console.ReadLine());
                                comp=Student.CheckIfExistsSTUDENT(id,connection);
                                if(comp)
                                {
                                    Console.WriteLine("Enter the New First Name: ");
                                    fname=Console.ReadLine() ?? "First Name Required!!!";
                                    Console.WriteLine("Enter the New last Name: ");
                                    lname=Console.ReadLine()?? "";
                                    Student.UpdateStudent(id,fname,lname,connection);
                                }
                                else
                                {
                                    Console.WriteLine("Cannot Update, NO Student exists with the ID: {0}",id);
                                }
                                break;
                            case 3:
                                Console.WriteLine("Enter the student id to be Deleted: ");
                                id=Convert.ToInt32(Console.ReadLine());
                                comp=Student.CheckIfExistsSTUDENT(id,connection);
                                if(comp)
                                {
                                    bool compareInScoreTable=ScoreCard.CheckIfExistsSCORECARD(id,connection);
                                    if(compareInScoreTable)
                                          Console.WriteLine("Delete the Marks in ScoreTable before deleting it here");
                                    else
                                        Student.DeleteStudent(id,connection);
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Cannot Delete, NO Student exists with the ID: {0}",id);
                                }
                                break;
                            case 4:
                                Student.DisplayStudent(connection);
                                break;
                            case 5:
                                Environment.Exit(0);
                                break;
                            default :
                                throw new Exception("Incorrect Choice! ");
                        }
                    }
    }


    public void CRUDOperationOnScoreCard(MySqlConnection connection)
    {
        while(true)
                    {
                        Console.WriteLine("Select 1 to Insert : ");
                        Console.WriteLine("Select 2 to Update All: ");
                        Console.WriteLine("Select 3 to Update Individual: ");
                        Console.WriteLine("Select 4 to Delete : ");
                        Console.WriteLine("Select 5 to Display : ");
                        Console.WriteLine("Select 6 to Exit: ");
                        int input=Convert.ToInt32(Console.ReadLine());

                        List<int> marks= new List<int>();
                        int id;
                        bool returnValue1, returnValue2;
                        switch(input)
                        {
                            case 1:
                                Console.WriteLine("Enter the ID: ");
                                id=Convert.ToInt32(Console.ReadLine());
                                returnValue1=Student.CheckIfExistsSTUDENT(id,connection);
                                if(returnValue1)
                                {
                                    returnValue2=ScoreCard.CheckIfExistsSCORECARD(id,connection);
                                    if(!returnValue2)
                                    {
                                        for(int i =1;i<=4;i++)
                                        {
                                            Console.WriteLine("Enter the marks for Subject {0} between 0-100",i);
                                            int val=Convert.ToInt32(Console.ReadLine());
                                            int afterCheck=CheckMark(val);
                                                marks.Add(afterCheck);
                                        }
                                        ScoreCard.InsertMarks(id,marks,connection);
                                    }
                                    else
                                        Console.WriteLine("Cannot Insert, Marks for the Student exists with the ID: {0}",id);
                                }
                                else
                                {
                                     Console.WriteLine("Cannot Insert ,There is no student with the ID: {0}",id);
                                }
                                
                                break;

                            case 2:
                                Console.WriteLine("Enter the ID to be updated: ");
                                id=Convert.ToInt32(Console.ReadLine());
                                returnValue1=Student.CheckIfExistsSTUDENT(id,connection);
                                
                                if(returnValue1)
                                {
                                    returnValue2=ScoreCard.CheckIfExistsSCORECARD(id,connection);
                                    if(!returnValue2)
                                    Console.WriteLine("Cannot Update, There is no student with the ID: {0}",id);
                                    else
                                    {
                                        for(int i =1;i<=4;i++)
                                        {
                                            Console.WriteLine("Enter the marks for Subject {0} between 0-100",i);
                                            int val=Convert.ToInt32(Console.ReadLine());
                                            int afterCheck=CheckMark(val);
                                            marks.Add(afterCheck);
                                        }
                                        ScoreCard.UpdateScoreCardAll(id,marks,connection);
                                    }
                                }
                                else
                                {
                                     Console.WriteLine("Cannot Update ,There is no student with the ID: {0}",id);
                                }    
                                break;

                            case 3:
                                 Console.WriteLine("Enter the ID to be updated: ");
                                 id=Convert.ToInt32(Console.ReadLine());
                                 returnValue1=Student.CheckIfExistsSTUDENT(id,connection);
                                
                                if(returnValue1)
                                {
                                    returnValue2=ScoreCard.CheckIfExistsSCORECARD(id,connection);
                                    if(!returnValue2)
                                    Console.WriteLine("Cannot Update, There is no student with the ID: {0}",id);
                                    else
                                    {
                                         Console.WriteLine("Enter the Subject Number to be updated:");
                                        int sub=Convert.ToInt32(Console.ReadLine());
                                        if(sub<=0 || sub>=5)
                                        {
                                            Console.WriteLine("Invalid subject Number");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter the new mark between 0-100");
                                                int val=Convert.ToInt32(Console.ReadLine());
                                                int afterCheck=CheckMark(val);
                                                marks.Add(afterCheck);
                                            ScoreCard.UpdateScoreCardIndividual(id,sub,afterCheck,connection);
                                        }
                                    }
                                }
                                else
                                {
                                     Console.WriteLine("Cannot Update ,There is no student with the ID: {0}",id);
                                } 
                                
                                break;

                            case 4:
                                Console.WriteLine("Enter the ID to be deleted: ");
                                id=Convert.ToInt32(Console.ReadLine());
                                returnValue1=Student.CheckIfExistsSTUDENT(id,connection);
                                
                                if(returnValue1)
                                {
                                    returnValue2=ScoreCard.CheckIfExistsSCORECARD(id,connection);
                                    if(!returnValue2)
                                        Console.WriteLine("Cannot Delete, There is no student with the ID: {0}",id);
                                    else
                                        ScoreCard.DeleteScoredCard(id,connection);
                                }
                                else
                                {
                                    Console.WriteLine("Cannot Delete ,There is no student with the ID: {0}",id);
                                }
                                break;

                            case 5:
                                ScoreCard.DisplayScoreCard(connection);
                                break;
                            case 6:
                                Environment.Exit(0);
                                break;
                            default :
                                throw new Exception("Incorrect Choice! ");
                        }
                    }
    }
    public int CheckMark(int val)
    {
        if(val<=100 && val>=0)
            return val;
        else if(val>=100)
            return 100;
        else
            return 0;
    }
    
}