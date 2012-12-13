using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.AstractFactory
{
    //Provide an interface for creating families of related or dependent objects 
    //without specifying their concrete classes.

    public interface IButton
    {
        void Paint();
    }

    public class OSXButton : IButton // Executes fourth if OS:OSX
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

    public interface IGUIFactory
    {
        IButton CreateButton();
    }

    public class OSXFactory : IGUIFactory // Executes third if OS:OSX
    {
        IButton CreateButton()
        {
            return new OSXButton();
        }
    }

    public class WinFactory : IGUIFactory // Executes third if OS:WIN
    {
        IButton CreateButton()
        {
            return new WinButton();
        }
    }

    public class ApplicationRunner
    {
        static IGUIFactory CreateOsSpecificFactory()  // Executes second
        {
            string sysType = "Win";
            if (sysType == "Win")
            {
                return new WinFactory();
            }
            else
            {
                return new OSXFactory();
            }
        }

        static void Main(string[] args) // Executes first
        {
            var button = CreateOsSpecificFactory().CreateButton();

            button.Paint();

            Console.ReadLine();
        }
    }

}
