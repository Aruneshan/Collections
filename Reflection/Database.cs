using System.Data.SqlClient;
namespace Reflection_Sample;

class Database
{
   
    static string connectionString ="Data Source=localhost\\SQLEXPRESS;Initial Catalog=Reflection;"
    
    public void DisplayUserDetails(){
         using (SqlConnection connection = new SqlConnection(connectionString))
        {
             string queryString ="select user_id from Login";
            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {   Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("| \t{0} \t |",
                        reader[0]);
                    
               
            }}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        connection.Close();
        }
        

        }
    public void insert(String username,String password)
    {

        // Provide the query string with a parameter placeholder.
        string queryString ="INSERT INTO Login (user_id,password) Values(@0,@1)";
        try{
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@0",username);
        command.Parameters.AddWithValue("@1",password);
        connection.Open();
        command.ExecuteReader();
        connection.Close();
        }
        catch(Exception e){
            Console.WriteLine(e);
            
        }
    
        }
        public Dictionary<string,string> UserDetails(Dictionary<string,string> userdetails){
         using (SqlConnection connection = new SqlConnection(connectionString))
        {
             string queryString ="select user_id,password from Login";
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@pricePoint", paramValue);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {   
                    if(!userdetails.ContainsKey(Convert.ToString(reader[0]))){
                        userdetails.Add(Convert.ToString(reader[0]),Convert.ToString(reader[1]));
                }
                
                
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             connection.Close();
        }
       
        return userdetails;

        }
        public void Update(string username,string newusername,string newpassword){
             string queryString ="UPDATE  Login SET  user_id=@0 ,password= @1 where user_id=@2; ";

        try{
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@0",newusername);
        command.Parameters.AddWithValue("@1",newpassword);
        command.Parameters.AddWithValue("@2",username);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        connection.Close();
        }
        catch(Exception e){
            Console.WriteLine(e);
            
        }

        }
         public void Delete(string username)
    {

        // Provide the query string with a parameter placeholder.
        string queryString ="DELETE from Login where user_id=@0;";
        try{
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@0",username);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        connection.Close();
        }
        catch(Exception e){
            Console.WriteLine(e);
            
        }
    
        }
        

        }
    
