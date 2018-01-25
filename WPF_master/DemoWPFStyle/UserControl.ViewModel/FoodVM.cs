using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using UserControl.Model;

namespace UserControl.ViewModel
{
    public class FoodVM
    {
        public ICommand DeleteCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ObservableCollection<Food> ListFoods { get; set; }
        public FoodVM()
        {
            ListFoods = new ObservableCollection<Food>() {
                new Food() {  Name="Gà rán", Price="1500300"},
                new Food() {  Name="Muối tiêu", Price="15000"}
            };
            DeleteCommand = new RelayCommand<Food>((p) => p != null, (p) => {
                ListFoods.Remove(p as Food);
            });
            InsertCommand = new RelayCommand<UIElementCollection>((p) => true, (p) => {
                Food fd = new Food();
                foreach (var i in p)
                {
                    var control =i as TextBox;
                    if (control == null) continue;
                    switch(control.Name)
                    {
                        case "txtName":
                            fd.Name = control.Text;
                            break;
                        case "txtPrice":
                            fd.Price = control.Text;
                            break;
                    }
                }
                ListFoods.Add(fd);
            });
            EditCommand = new RelayCommand<UIElementCollection>((p) => p != null, (p) => {
                Food xx = new Food();

                foreach (var i in p)
                {
                    var control = i as TextBox;
                    if (control == null) continue;
                    switch (control.Name)
                    {
                        case "txtName":
                             xx = ListFoods.Single(x => x.Name == control.Text);
                            break;
                        //case "txtPrice":
                        //    ListFoods.Single(x => x.Name == control.Text).Price = control.Text;
                        //    break;
                    }
                }
              

            });
        }
    }
}
