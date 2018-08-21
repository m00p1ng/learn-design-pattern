using System;

namespace Decorator
{
    public interface IBird
    {
        void Fly();
    }

    public interface ILizard
    {
        void Crawl();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine("Soaring in the sky");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine("Crawling in the dirt");
        }
    }

    public class Dragon : IBird, ILizard
    {
        Bird bird = new Bird();
        Lizard lizard = new Lizard();
        int weight;

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }

        public int Weight { 
            get { 
                return weight;
            } 
            set {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }
    }
}
