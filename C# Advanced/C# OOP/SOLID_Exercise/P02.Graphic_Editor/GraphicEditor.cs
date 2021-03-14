using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Type type = shape.GetType();
            Shape instance = Activator.CreateInstance(type) as Shape;

            Console.WriteLine(instance.DrawShape());
        }
    }
}
