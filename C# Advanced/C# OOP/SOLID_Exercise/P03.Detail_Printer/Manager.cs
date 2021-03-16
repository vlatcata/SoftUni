using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        private IReadOnlyCollection<string> documents;
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Documents}";
        }
    }
}
