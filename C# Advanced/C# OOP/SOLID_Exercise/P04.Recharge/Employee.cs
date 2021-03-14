namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {

        }

        public override void Sleep()
        {
            Console.WriteLine("sleeping...");
        }

        public override void Recharge()
        {
            throw new InvalidOperationException("Employee cannot recharge");
        }
    }
}
