using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPizza.Model
{
    class Pizza
    {
        public string Size { get; set; }
        public List<Ingreedient> Ingreedients { get; set; }        

        public override string ToString()
        {
            string ingreedients = "";
            foreach (var ingreedient in Ingreedients)
            {
                ingreedients += ingreedient.Name+", ";
            }
            return Size + ": " + ingreedients;
        }

        public string GetPrice(Pizza pizzaToOrder)
        {
            int amount = 0;
            foreach (var ingreedient in pizzaToOrder.Ingreedients)
            {
                amount += ingreedient.Price;
            }
            if (pizzaToOrder.Size == "small")
            {
                amount += 300;
            }
            else if (pizzaToOrder.Size == "medium")
            {
                amount += 500;
            }
            else if (pizzaToOrder.Size == "big")
            {
                amount += 700;
            }
            return amount.ToString();
        }
    }
}
