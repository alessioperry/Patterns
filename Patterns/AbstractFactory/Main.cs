using System;

namespace Patterns.AbstractFactory
{
    //Provide an interface for creating families of related or dependent objects 
    //without specifying their concrete classes.

    public interface IButton
    {
        void Paint();
    }

    public class OsxButton : IButton // Executes fourth if OS:OSX
    {
        public void Paint()
        {
            System.Console.WriteLine("I'm an OSXButton");
        }
    }

    public class WinButton : IButton // Executes fourth if OS:WIN
    {
        public void Paint()
        {
            System.Console.WriteLine("I'm a WinButton");
        }
    }

    public interface IGuiFactory
    {
        IButton CreateButton();
    }

    public class OsxFactory : IGuiFactory // Executes third if OS:OSX
    {
        public IButton CreateButton()
        {
            return new OsxButton();
        }
    }

    public class WinFactory : IGuiFactory // Executes third if OS:WIN
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
    }

    public class ApplicationRunner
    {
        static IGuiFactory CreateOsSpecificFactory()  // Executes second
        {
            return new WinFactory();
        }

        static void Main(string[] args) // Executes first
        {
            var button = CreateOsSpecificFactory().CreateButton();

            button.Paint();

            Console.ReadLine();
        }
    }

}
