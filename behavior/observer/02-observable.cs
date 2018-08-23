using System;
using System.ComponentModel;

namespace RxDemos
{
    public class Market
    {
        public void AddPrice(float price)
        {
            Prices.Add(price);
        }
        public BindingList<float> Prices = new BindingList<float>();
    }

    public class PriceAddedEventArgs
    {
        public float Price;
    }

    public class ObserverPattern
    {
        static void MainOP()
        {
            Market market = new Market();
            market.Prices.ListChanged += (sender, eventArgs) =>
            {
                if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    Console.WriteLine($"Added price {((BindingList<float>)sender)[eventArgs.NewIndex]}");
                }
            };
            market.AddPrice(123);
        }
    }
}