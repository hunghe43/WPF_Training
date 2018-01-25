using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMSAMPLE
{
    public class FoodViewModel
    {
        public ObservableCollection<Food> Foods { get; set; }
        Food Food { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public FoodViewModel()
        {
            Food = new Food();
            Foods = new ObservableCollection<Food>() {
                new Food() {  Name="Sữa chua mít", Note="Sữa chua trộn mít"},
                new Food() {  Name="Nem chua rán", Note="Nem chua mang rán"}
            };
            DeleteCommand = new RelayCommand<Food>((p) => p != null, (p) => {
                Foods.Remove(p as Food);
            });
            InsertCommand = new RelayCommand<UIElementCollection>((p) => true, (p) => {
                Food f=new Food();
                if (p != null)
                {

                    foreach (var item in p)
                    {
                        var control = item as TextBox;
                        if (control == null) continue;
                        switch (control.Name)
                        {
                            case "txtName":
                                f.Name = control.Text;
                                break;
                            case "txtNote":
                                f.Note = control.Text;
                                break;
                        }
                    }
                    if(!string.IsNullOrEmpty(f.Name))
                    Foods.Add(f);
                }
              
            });
            UpdateCommand = new RelayCommand<Food>((p) => p != null, (p) => {
                
            });
        }

    }
}
