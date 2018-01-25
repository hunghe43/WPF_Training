using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSAMPLE
{
    public class Food 
    {
        private string _name;
        private string _note;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;

                   // OnPropertyChanged("Name");
                }
            }
        }
        public string Note
        {
            get { return _note; }
            set {
                if (_note != value)
                {
                    _note = value;
                   // OnPropertyChanged("Note");
                }
            }
        }
    }
    public  abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
