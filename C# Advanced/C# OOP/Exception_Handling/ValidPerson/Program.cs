using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", "Peshev", 24);

            try
            {
                Person noName = new Person(string.Empty, "Goshev", 31);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exeption thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exeption thrown: {0}", ex.Message);
            }
        }
    }
}
