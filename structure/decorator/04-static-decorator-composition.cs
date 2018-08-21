using System;

namespace Decorator
{
    public abstract class Shape
    {
        public virtual string AsString() => string.Empty;
    }

    public class Circle : Shape
    {
        float radius;

        public Circle() : this(0)
        {

        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public override string AsString() => $"A circle of radius {radius}";
    }

    public class Square : Shape
    {
        float side;

        public Square() : this(0)
        {

        }

        public Square(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"A square with side {side}";
    }

    // dynamic
    public class ColoredShape : Shape
    {
        Shape shape;
        string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparentShape : Shape
    {
        Shape shape;
        float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f} transparency";
    }

    // CRTP cannot be done
    //public class ColoredShape2<T> : T where T : Shape { }

    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        string color;
        T shape = new T();

        public ColoredShape() : this("black")
        {

        }

        public ColoredShape(string color) // no constructor forwarding
        {
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        float transparency;
        T shape = new T();

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has transparency {transparency * 100.0f}";
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            Console.WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            Console.WriteLine(redSquare.AsString());

            var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            Console.WriteLine(redHalfTransparentSquare.AsString());

            // static
            ColoredShape<Circle> blueCircle = new ColoredShape<Circle>("blue");
            Console.WriteLine(blueCircle.AsString());

            TransparentShape<ColoredShape<Square>> blackHalfSquare = new TransparentShape<ColoredShape<Square>>(0.4f);
            Console.WriteLine(blackHalfSquare.AsString());
        }
    }
}