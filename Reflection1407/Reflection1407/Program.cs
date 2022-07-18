using System.Reflection;
using System.Text;

namespace Reflection1407
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayPublicProperties();
            CreateInstance();

            void DisplayPublicProperties()
            {
                Type studentType = typeof(Student);

                PropertyInfo[] properties = studentType.GetProperties();

                foreach (var propertyInfo in properties)
                {
                    Console.WriteLine(propertyInfo.Name);
                }
                Console.Read();
            }

          
            void CreateInstance()
            {
                var student = Activator.CreateInstance<Student>();

                PropertyInfo[] propertyInfos = student.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name == "Name")
                    {
                        propertyInfo.SetValue(student, "Isabella Laporte");
                    }
                    if (propertyInfo.Name == "RollNumber")
                    {
                        propertyInfo.SetValue(student, 364);
                    }
                    if (propertyInfo.Name == "University")
                    {
                        propertyInfo.SetValue(student, "Unicamp");
                    }
                }
                MethodInfo[] methodInfos = student.GetType().GetMethods();
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    if (methodInfo.Name.Equals("DisplayInfo", StringComparison.Ordinal))
                    {
                        methodInfo.Invoke(student, null);
                    }
                }
            }
        }
    }
}

