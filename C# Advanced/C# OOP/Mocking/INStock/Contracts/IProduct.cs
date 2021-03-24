using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Contracts
{
    public interface IProduct : IComparable<IProduct>
    {
        string Label { get;}

        decimal Price { get; }

        int Quantity { get; }
    }
}
