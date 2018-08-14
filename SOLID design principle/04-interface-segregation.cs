using System;

namespace SOLID
{
    public class Document
    {
            
    }

    // public interface IMachine
    // {
    //     void Print(Document document);
    //     void Scan(Document document);
    //     void Fax(Document document);
    // }

    // public class MultiFunctionPrinter: IMachine
    // {
    //     public void Print(Document document)
    //     {

    //     }

    //     public void Scan(Document document)
    //     {
            
    //     }

    //     public void Fax(Document document)
    //     {
            
    //     }
    // }

    // public class OldFashionedPrinter : IMachine
    // {
    //     public void Print(Document document)
    //     {
            
    //     }

    //     public void Scan(Document document)
    //     {
            
    //     }

    //     public void Fax(Document document)
    //     {
            
    //     }
    // }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            throw new NotImplementedException(); 
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException(); 
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter
    {
        
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if(printer == null)
            {
                throw ArgumentNullException(paramName: nameof(printer));
            }
            if (printer == null)
            {
                throw ArgumentNullException(paramName: nameof(printer));
            }
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document document)
        {
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            scanner.Scan(document);
        }
    }

    class Demon
    {
        public static void Main(string[] args)
        {
        }
    }
}
