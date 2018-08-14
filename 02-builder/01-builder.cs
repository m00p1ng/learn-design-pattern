using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Element = new List<HtmlElement>();
        const int indentSize = 2;

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(name));
        }

        string ToStringImpl(int indent) 
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if(!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach(var e in Element) 
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString() 
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        readonly string rootName;
        HtmlElement root = new HtmlElement("", "");

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Element.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement(rootName, "");
        }
    }

    class Demo
    {
        public static void Main()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello").AddChild("li", "world");

            Console.WriteLine(builder);
        }
    }
}
