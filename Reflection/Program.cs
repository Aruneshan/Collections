using System.Data.SqlClient;
namespace Reflection_Sample;
using System.Reflection;
class Program
{
    static void Main()

    {
       Type t=typeof(Database);
       Console.WriteLine($"Class is {t}");

       PropertyInfo[] pr = t.GetProperties();
       foreach(PropertyInfo pro in pr){
        Console.WriteLine($"Field is {pro}");

       }

       FieldInfo[] fi=t.GetFields();
       foreach(FieldInfo fio in fi){
        Console.WriteLine($"Field is {fio}");

       }

       MethodInfo[] m=t.GetMethods();
       foreach(MethodInfo mi in m ){
        
        ParameterInfo[] p=mi.GetParameters();
        Console.WriteLine($"parameters of {mi}");
        foreach(ParameterInfo pi in p){
            
            Console.WriteLine(pi);

        }

       }
       Login login = new Login();
       
        
        
        }
    }