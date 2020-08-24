using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfPizza.Model;

namespace WpfPizza.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            sizes = new List<string>() { "small", "medium", "big" };
            pizzaToOrder = new Pizza();
            ordered = true;
        }

        #endregion

        #region Properties

        private List<string> sizes;

        public List<string> Sizes
        {
            get { return sizes; }
            set
            {
                sizes = value;
                OnPropertyChanged("Sizes");
            }
        }

        private Pizza pizzaToOrder;

        public Pizza PizzaToOrder
        {
            get { return pizzaToOrder; }
            set
            {
                pizzaToOrder = value;
                OnPropertyChanged("PizaToOrder");
            }
        }

        private string amount;

        public string Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private string size;

        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        private bool salami;

        public bool Salami
        {
            get { return salami; }
            set
            {
                salami = value;
                OnPropertyChanged("Salami");
            }
        }

        private bool ham;

        public bool Ham
        {
            get { return ham; }
            set
            {
                ham = value;
                OnPropertyChanged("Ham");
            }
        }

        private bool pepperoni;

        public bool Pepperoni
        {
            get { return pepperoni; }
            set
            {
                pepperoni = value;
                OnPropertyChanged("Pepperoni");
            }
        }

        private bool ketchup;

        public bool Ketchup
        {
            get { return ketchup; }
            set
            {
                ketchup = value;
                OnPropertyChanged("Ketchup");
            }
        }

        private bool mayo;

        public bool Mayo
        {
            get { return mayo; }
            set
            {
                mayo = value;
                OnPropertyChanged("Mayo");
            }
        }

        private bool paprika;

        public bool Paprika
        {
            get { return paprika; }
            set
            {
                paprika = value;
                OnPropertyChanged("Paprika");
            }
        }

        private bool olives;

        public bool Olives
        {
            get { return olives; }
            set
            {
                olives = value;
                OnPropertyChanged("Olives");
            }
        }

        private bool origano;

        public bool Origano
        {
            get { return origano; }
            set
            {
                origano = value;
                OnPropertyChanged("Origano");
            }
        }

        private bool sesame;

        public bool Sesame
        {
            get { return sesame; }
            set
            {
                sesame = value;
                OnPropertyChanged("Sesame");
            }
        }

        private bool cheese;

        public bool Cheese
        {
            get { return cheese; }
            set
            {
                cheese = value;
                OnPropertyChanged("Cheese");
            }
        }

        private bool ordered;

        public bool Ordered
        {
            get { return ordered; }
            set
            {
                ordered = value;
                OnPropertyChanged("Ordered");
            }
        }

        #endregion

        #region Commands

        private ICommand calculateAmount;

        public ICommand CalculateAmount
        {
            get
            {
                if (calculateAmount == null)
                {
                    calculateAmount = new RelayCommand(param => CalculateAmountExecute(), param => CanCalculateAmountExecute());
                }

                return calculateAmount;
            }
        }

        private void CalculateAmountExecute()
        {
            try
            {
                pizzaToOrder.Ingreedients = new List<Ingreedient>();
                if (salami)
                {
                    Ingreedient s = new Ingreedient("salami", 50);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (ham)
                {
                    Ingreedient s = new Ingreedient("ham", 60);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (pepperoni)
                {
                    Ingreedient s = new Ingreedient("pepperoni", 60);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (ketchup)
                {
                    Ingreedient s = new Ingreedient("ketchup", 40);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (mayo)
                {
                    Ingreedient s = new Ingreedient("mayo", 30);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (paprika)
                {
                    Ingreedient s = new Ingreedient("paprika", 40);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (olives)
                {
                    Ingreedient s = new Ingreedient("olives", 50);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (origano)
                {
                    Ingreedient s = new Ingreedient("origano", 20);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (sesame)
                {
                    Ingreedient s = new Ingreedient("sesame", 50);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                if (cheese)
                {
                    Ingreedient s = new Ingreedient("cheese", 50);
                    PizzaToOrder.Ingreedients.Add(s);
                }
                PizzaToOrder.Size = Size;
                Amount = PizzaToOrder.GetPrice(PizzaToOrder);
                Ordered = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCalculateAmountExecute()
        {
            if (Size != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
