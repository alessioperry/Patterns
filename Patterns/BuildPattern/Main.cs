using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BuildPattern
{
    //Separate the construction of a complex object from its representation allowing the same construction process to create various representations.
    
    // Product - The final object that will be created by the Director using Builder
    public class Pizza
    {
        public string Dough = string.Empty;
        public string Sauce = string.Empty;
        public string Topping = string.Empty;
    }

    // Builder - abstract interface for creating objects (the product, in this case)
    abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza GetPizza()
        {
            return pizza;
        }

        public void CreateNewPizzaProduct()
        {
            pizza = new Pizza();
        }

        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }
    // Concrete Builder - provides implementation for Builder; an object able to construct other objects.
    // Constructs and assembles parts to build the objects
    class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.Dough = "cross";
        }

        public override void BuildSauce()
        {
            pizza.Sauce = "mild";
        }

        public override void BuildTopping()
        {
            pizza.Topping = "ham+pineapple";
        }
    }
    // Concrete Builder - provides implementation for Builder; an object able to construct other objects.
    // Constructs and assembles parts to build the objects
    class SpicyPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.Dough = "pan baked";
        }

        public override void BuildSauce()
        {
            pizza.Sauce = "hot";
        }

        public override void BuildTopping()
        {
            pizza.Topping = "pepperoni + salami";
        }
    }

    // Director - responsible for managing the correct sequence of object creation.
    // Receives a Concrete Builder as a parameter and executes the necessary operations on it.
    interface ICook {
        void SetPizzaBuilder(PizzaBuilder pizzaBuilder);
        Pizza GetPizza();
        void ConstructPizza();
    }

    class Cook : ICook
    {
        private PizzaBuilder pizzaBuilder;

        public void SetPizzaBuilder(PizzaBuilder pizzaBuilder)
        {
            this.pizzaBuilder = pizzaBuilder;
        }

        public Pizza GetPizza()
        {
            return pizzaBuilder.GetPizza();
        }

        public void ConstructPizza()
        {
            pizzaBuilder.CreateNewPizzaProduct();
            pizzaBuilder.BuildDough();
            pizzaBuilder.BuildSauce();
            pizzaBuilder.BuildTopping();
        }
    }

    class Program
    {
        private ICook cook;

        public Program(ICook cook) {
            this.cook = cook;
        }

        void Main(string[] args)
        {
            cook.SetPizzaBuilder(new HawaiianPizzaBuilder());
            cook.ConstructPizza();
            // create the product
            Pizza hawaiian = cook.GetPizza();

            cook.SetPizzaBuilder(new SpicyPizzaBuilder());
            cook.ConstructPizza();
            // create another product
            Pizza spicy = cook.GetPizza();
        }
    }
}
