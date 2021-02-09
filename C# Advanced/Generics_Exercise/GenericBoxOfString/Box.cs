using System;
using System.Collections.Generic;
using System.Text;

namespace Generics_Exercise
{
   public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            Type valueType = Value.GetType();
            string valueTypeFullName = valueType.FullName;

            return $"{valueTypeFullName}: {Value}";
        }
    }
}
