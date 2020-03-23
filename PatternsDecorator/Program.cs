using System;

namespace PatternsDecorator
{
    class Program
    {
        /// <summary>
        /// Выводит все пиццы которые мы хотим вместес ценой
        /// </summary>
        static void Main(string[] args)
        {

            Console.WriteLine("Введите базовую цену пиццы");
            while (true)
                try
                {
                    Pizza.SetPrice(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Здесь должна была быть цифра");
                }
            Console.WriteLine("Введите надбавку для американской пиццы");
            while (true)
                try
                {
                    AmericanPizza.SetAddPrice(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Здесь должна была быть цифра");
                }

            Console.WriteLine("Введите надбавку для итальянской пиццы");
            while (true)
                try
                {
                    ItalianPizza.SetAddPrice(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Здесь должна была быть цифра");
                }

            Pizza pizza1 = new AmericanPizza();
            pizza1 = new MushroomsPizza(pizza1); // Америкаская пицца с грибами
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());

            Pizza pizza2 = new AmericanPizza();
            pizza2 = new CheesePizza(pizza2);// Америкасная пицца пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new ItalianPizza();
            pizza3 = new MushroomsPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// Итальянская пиццы с грибами и сыром
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());

            Pizza pizza4 = new AmericanPizza();
            Console.WriteLine("Название: {0}", pizza4.Name); // Американская пицца
            Console.WriteLine("Цена: {0}", pizza4.GetCost());

            Pizza pizza5 = new ItalianPizza();
            Console.WriteLine("Название: {0}", pizza5.Name); // Итальянская пицца
            Console.WriteLine("Цена: {0}", pizza5.GetCost());

            Console.ReadLine();
        }
    }
    /// <summary>
    ///  определяет баззовую функциональность 
    /// </summary>
    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }

        public static void SetPrice(int price) // Базовая цена пиццы
        {
            basePrice = price;
        }
        public string Name { get; protected set; }

        public abstract int GetCost();
        protected static int basePrice = 0; // базовая цена
    }
    /// <summary>
    ///  Американска пицца и ее цена
    /// </summary>
    class AmericanPizza : Pizza
    {
        public AmericanPizza() : base("Американская пицца")
        { }
        protected static int addPrice = 0;
        public static void SetAddPrice(int price) // надбавка на американскую пиццу
        {
            addPrice = price;
        }
        public override int GetCost()
        {
            return basePrice + addPrice;
        }
    }
    /// <summary>
    /// Итальянская пицца и ее цена
    /// </summary>
    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        protected static int addPrice = 0;
        public static void SetAddPrice(int price) // надбавка на итальянскую пиццу
        {
            addPrice = price;
        }
        public override int GetCost()
        {
            return basePrice + addPrice;
        }
    }
    /// <summary>
    /// Сам декаратор который требуется по ТЗ
    /// </summary>
    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }
    /// <summary>
    /// добовление к пицце грибов и цена грибов
    /// </summary>
    class MushroomsPizza : PizzaDecorator
    {
        public MushroomsPizza(Pizza p) : base(p.Name + ", с грибами", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 2;
        }
    }
    /// <summary>
    /// добовление сыра к пицце и цена сыра
    /// </summary>
    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p) : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 1;
        }
    }

}
