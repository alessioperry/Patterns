using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FactoryMethod
{
    //Define an interface for creating an object, but let subclasses decide which class to 
    //instantiate. Factory Method lets a class defer instantiation to subclasses 

    //complex class is completly protected to external env
    public class Complex
    {
        public readonly double real{get; private set;}
        public readonly double imaginary{get; private set;}
 
        //desired constructor
        public static Complex FromCartesianFactory(double real, double imaginary ) 
        {
            return new Complex(real, imaginary);
        }
 
        //desired constructor
        public static Complex FromPolarFactory(double modulus , double angle ) 
        {
            return new Complex(modulus * Math.Cos(angle), modulus * Math.Sin(angle));
        }
 
        //private constructor
        private Complex (double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
    }
 
     class Program
    {
        void Main(string[] args)
        {
            var complexNumber = Complex.FromPolarFactory(1, 48);

            var real = complexNumber.real;
            var immaginary = complexNumber.imaginary;
        }
    }


}
