using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestReadWriteXML_WPF.Entity
{
    public class ItemDetail : INotifyPropertyChanged
    {
        private decimal _price;
        private int _quantity;


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id { get; set; }
        public string ItemId { get; set; }
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value != this.Price)
                {
                    _price = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Total");
                }
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Total");
                }
            }
        }
        public decimal Total
        {
            get { return _price * _quantity; }
        }
    }
}

