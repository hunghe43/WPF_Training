using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using TestReadWriteXML_WPF.ChildWindow.View;
using TestReadWriteXML_WPF.ChildWindow.ViewModel;
using TestReadWriteXML_WPF.Entity;

namespace TestReadWriteXML_WPF.ViewModel
{
    public class ItemViewModel
    {
        public ObservableCollection<Item> ListItem { get; set; }
        public ICommand ShowDialog { get; set; }
        public ICommand ViewDetails { get; set; }
        public ICommand DeleteItem { get; set; }
        public ICommand SearchItem { get; set; }
        public Item Item { get; set; }
        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string path = "D:/WORKING_Hung/GITHUB/QLMN_WPF_Project/TestReadWriteXML_WPF/TestReadWriteXML_WPF/DATA1.xml";
        public ItemViewModel()
        {
            ListItem = getListItem();
            ShowDialog = new RelayCommand<object>((p) => true, onShowDialog);
            DeleteItem = new RelayCommand<object>((p) => true, onDeleteItem);
            ViewDetails = new RelayCommand<Item>(p => true, onShowViewDetail);
            SearchItem = new RelayCommand<object>(p => true, onSearchItem);
            doc.Load(path);
            root = doc.DocumentElement;
        }
        public ItemViewModel(ObservableCollection<Item> Items)
        {
            ListItem = Items;
            ShowDialog = new RelayCommand<object>((p) => true, onShowDialog);
            DeleteItem = new RelayCommand<object>((p) => true, onDeleteItem);
            ViewDetails = new RelayCommand<Item>((p) => true, onShowViewDetail);
            SearchItem = new RelayCommand<object>((p)=>true, onSearchItem);
            doc.Load(path);
            root = doc.DocumentElement;
        }
        private void onSearchItem(object parameter)
        {
            try
            {

                var values = (object[])parameter;
                var window = (Window)values[0];
                var txtsearch = (TextBox)values[1];
                ObservableCollection<Item> listItemSearch = new ObservableCollection<Item>();
                string stringSearch = txtsearch.Text.Trim();
                if (string.IsNullOrEmpty(stringSearch))
                {
                    listItemSearch = getListItem();
                }
                else
                {

                    foreach (var item in getListItem())
                    {
                        if (item.Id.Contains(stringSearch) || (item.Name.Contains(stringSearch) || (item.Unit.Contains(stringSearch))))
                        {
                            listItemSearch.Add(item);
                        }
                    }
                }
                window.DataContext = new ItemViewModel(listItemSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void onShowViewDetail(Item parameter)
        {
            ItemDetailWindow childWindow = new ItemDetailWindow() { DataContext = new DialogItemViewModel(parameter) };
            childWindow.ShowDialog();
        }
        private void onDeleteItem(object parameter)
        {
            try
            {
                var values = (object[])parameter;
                var window = (Window)values[0];
                var listitem = (DataGrid)values[1];
                Item item = listitem.SelectedValue as Item;
                if (item != null)
                {
                    XmlNode itemDelete = root.SelectSingleNode("Item[Id='" + item.Id + "']");
                    if (itemDelete != null)
                    {
                        root.RemoveChild(itemDelete);
                        doc.Save(path);
                    }
                    window.DataContext = new ItemViewModel();
                    MessageBox.Show("sussces!");

                }
                MessageBox.Show("Chưa chọn item!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void onShowDialog(object parameter)
        {
            if (parameter == null)
            {
                ItemChildWindow child = new ItemChildWindow() { DataContext = new DialogItemViewModel() };
                child.ShowDialog();
            }
            else
            {
                ItemChildWindow child = new ItemChildWindow() { DataContext = new DialogItemViewModel(parameter as Item) };
                child.ShowDialog();
            }
        }
        private ObservableCollection<Item> getListItem()
        {
            ListItem = new ObservableCollection<Item>();
            try
            {
                ObservableCollection<ItemDetail> listDetails;
                Item item;
                ItemDetail detail;
                doc.Load(path);
                foreach (XmlNode node in doc.DocumentElement)
                {
                    item = new Item();

                    item.Id = node.Attributes["id"].InnerText;
                    item.Name = node["Name"].InnerText;
                    item.Unit = node["Unit"].InnerText;
                    item.CreateDate = Convert.ToDateTime(node["CreateDate"].InnerText);
                    if (node.FirstChild.InnerText == item.Id)
                    {
                        listDetails = new ObservableCollection<ItemDetail>();
                        foreach (XmlNode nodeDetail in node.LastChild.ChildNodes)
                        {
                            detail = new ItemDetail();
                            detail.Id = nodeDetail.Attributes["Id"].InnerText;
                            detail.ItemId = nodeDetail["ItemId"].InnerText;
                            if (string.IsNullOrEmpty(nodeDetail["Price"].InnerText))
                                detail.Price = 0;
                            else
                                detail.Price = int.Parse(nodeDetail["Price"].InnerText);
                            if (string.IsNullOrEmpty(nodeDetail["Quantity"].InnerText))
                                detail.Quantity = 0;
                            else
                                detail.Quantity = int.Parse(nodeDetail["Quantity"].InnerText);
                            listDetails.Add(detail);
                        }
                        item.ItemDetails = listDetails;
                    }
                    ListItem.Add(item);
                }
                return ListItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ListItem;

            }
        }

    }
}
