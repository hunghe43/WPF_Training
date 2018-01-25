using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using TestReadWriteXML_WPF.Entity;
using TestReadWriteXML_WPF.ViewModel;

namespace TestReadWriteXML_WPF.ChildWindow.ViewModel
{
    public class DialogItemViewModel
    {
        public ICommand ExcuteItem { get; set; }
        public ICommand ExcuteDetail { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand DeleteDetail { get; set; }
        public Item ItemModel { get; set; }
        public ICollection<ItemDetail> ListItemDetail { get; set; }
        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string path = "D:/WORKING_Hung/GITHUB/QLMN_WPF_Project/TestReadWriteXML_WPF/TestReadWriteXML_WPF/DATA.xml";
        public DialogItemViewModel()
        {
            LoadXML();
            ExcuteItem = new RelayCommand<object>(p => true, onExcute);
            Cancel = new RelayCommand<Window>((p) => true, onCancel);
        }

        public DialogItemViewModel(Item item)
        {
            LoadXML();
            ListItemDetail = item.ItemDetails;
            ItemModel = item;
            ExcuteItem = new RelayCommand<object>(p => true, onExcute);
            Cancel = new RelayCommand<Window>((p) => true, onCancel);
            ExcuteDetail = new RelayCommand<object>((p) => true, onExcuteDetails);
            DeleteDetail = new RelayCommand<object>((p) => true, onDelelteDetail);
        }
        private Item getItemforId(string id)
        {
            Item item = new Item();
            XmlNode nodeitem = root.SelectSingleNode("Item[Id='" + id + "']");
            //node ItemDetails
            XmlNode details = nodeitem.SelectSingleNode("ItemDetails");
            try
            {
                ObservableCollection<ItemDetail> listDetails;

                ItemDetail detail;
                doc.Load(path);
                item.Id = nodeitem["Id"].InnerText;
                item.Name = nodeitem["Name"].InnerText;
                item.Unit = nodeitem["Unit"].InnerText;
                item.CreateDate = Convert.ToDateTime(nodeitem["CreateDate"].InnerText);
                if (nodeitem.FirstChild.InnerText == item.Id)
                {
                    listDetails = new ObservableCollection<ItemDetail>();
                    foreach (XmlNode nodeDetail in details)
                    {
                        detail = new ItemDetail();
                        detail.Id = nodeDetail["Id"].InnerText;
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

                return item;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return item;

            }
        }
        private void LoadXML()
        {
            doc.Load(path);
            root = doc.DocumentElement;
        }
        private void onDelelteDetail(object parameter)
        {
            try
            {
                var values = (object[])parameter;
                var window = (Window)values[0];
                var listitem = (DataGrid)values[1];
                Item item = ItemModel;
                ItemDetail detail = listitem.SelectedValue as ItemDetail;
                if (detail != null)
                {
                    XmlNode nodeitem = root.SelectSingleNode("Item[Id='" + item.Id + "']");
                    //node ItemDetails
                    XmlNode details = nodeitem.SelectSingleNode("ItemDetails");

                    XmlNode detailsDelete = details.SelectSingleNode("ItemDetail[Id='" + detail.Id + "']");

                    if (detailsDelete != null)
                    {
                        details.RemoveChild(detailsDelete);
                        doc.Save(path);
                    }
                    window.DataContext = new DialogItemViewModel(getItemforId(item.Id));
                    MessageBox.Show("sussces!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void onCancel(Window window)
        {
            if (window != null)
                window.Close();
        }
        private void onExcute(object parameter)
        {

            var value = (object[])parameter;
            var childWindow = (Window)value[0];
            var wrap = (WrapPanel)value[1];
            var txtID = (TextBlock)value[2];

            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    Item item = new Item();
                    foreach (object child in wrap.Children)
                    {
                        string childname = null;
                        if (child is FrameworkElement)
                        {
                            childname = (child as FrameworkElement).Name;
                            switch (childname)
                            {
                                case "txtItemID":
                                    item.Id = (child as TextBlock).Text;

                                    break;
                                case "txtName":
                                    item.Name = (child as TextBox).Text;
                                    break;
                                case "txtUnit":
                                    item.Unit = (child as TextBox).Text;
                                    break;
                                case "dtCreate":
                                    item.CreateDate = (child as DatePicker).SelectedDate.Value;
                                    break;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(item.Id))
                    {
                        Random rd = new Random();
                        item.Id = Convert.ToString(rd.Next(1, 100)) + "_id_" + Convert.ToString(rd.Next(1, 100));

                        XmlElement itemxml = doc.CreateElement("Item");

                        XmlElement Id = doc.CreateElement("Id");
                        Id.InnerText = item.Id;
                        itemxml.AppendChild(Id);

                        XmlElement Name = doc.CreateElement("Name");
                        Name.InnerText = item.Name;
                        itemxml.AppendChild(Name);

                        XmlElement Unit = doc.CreateElement("Unit");
                        Unit.InnerText = item.Unit;
                        itemxml.AppendChild(Unit);

                        XmlElement CreateDate = doc.CreateElement("CreateDate");
                        CreateDate.InnerText = item.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
                        itemxml.AppendChild(CreateDate);

                        XmlElement ItemDetails = doc.CreateElement("ItemDetails");
                        XmlElement Details = doc.CreateElement("ItemDetail");

                        XmlElement IdDetail = doc.CreateElement("Id");
                        IdDetail.InnerText = "";
                        Details.AppendChild(IdDetail);

                        XmlElement ItemId = doc.CreateElement("ItemId");
                        ItemId.InnerText = item.Id;
                        Details.AppendChild(ItemId);

                        XmlElement Price = doc.CreateElement("Price");
                        Price.InnerText = "0";
                        Details.AppendChild(Price);

                        XmlElement Quantity = doc.CreateElement("Quantity");
                        Quantity.InnerText = "0";
                        Details.AppendChild(Quantity);

                        ItemDetails.AppendChild(Details);
                        itemxml.AppendChild(ItemDetails);

                        root.AppendChild(itemxml);
                        doc.Save(path);
                    }
                }
                else
                {
                    Item item = ItemModel;
                    foreach (object child in wrap.Children)
                    {
                        string childname = null;
                        if (child is FrameworkElement)
                        {
                            childname = (child as FrameworkElement).Name;
                            switch (childname)
                            {
                                case "txtItemID":
                                    item.Id = (child as TextBlock).Text;

                                    break;
                                case "txtName":
                                    item.Name = (child as TextBox).Text;
                                    break;
                                case "txtUnit":
                                    item.Unit = (child as TextBox).Text;
                                    break;
                                case "dtCreate":
                                    item.CreateDate = (child as DatePicker).SelectedDate.Value;
                                    break;
                            }
                        }
                    }

                    XmlNode itemold = root.SelectSingleNode("Item[Id='" + item.Id + "']");
                    if (itemold != null)
                    {
                        XmlNode itemNew = doc.CreateElement("Item");

                        XmlElement Id = doc.CreateElement("Id");
                        Id.InnerText = item.Id;
                        itemNew.AppendChild(Id);

                        XmlElement Name = doc.CreateElement("Name");
                        Name.InnerText = item.Name;
                        itemNew.AppendChild(Name);

                        XmlElement Unit = doc.CreateElement("Unit");
                        Unit.InnerText = item.Unit;
                        itemNew.AppendChild(Unit);

                        XmlElement CreateDate = doc.CreateElement("CreateDate");
                        CreateDate.InnerText = item.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
                        itemNew.AppendChild(CreateDate);

                        XmlElement ItemDetails = doc.CreateElement("ItemDetails");

                        if (item.ItemDetails.Count != 0)
                        {

                            foreach (ItemDetail details in item.ItemDetails)
                            {
                                XmlElement Details = doc.CreateElement("ItemDetail");

                                XmlElement IdDetail = doc.CreateElement("Id");
                                IdDetail.InnerText = details.Id.ToString();
                                Details.AppendChild(IdDetail);

                                XmlElement ItemId = doc.CreateElement("ItemId");
                                ItemId.InnerText = details.ItemId.ToString();
                                Details.AppendChild(ItemId);

                                XmlElement Price = doc.CreateElement("Price");
                                Price.InnerText = details.Price.ToString();
                                Details.AppendChild(Price);

                                XmlElement Quantity = doc.CreateElement("Quantity");
                                Quantity.InnerText = details.Quantity.ToString();
                                Details.AppendChild(Quantity);

                                ItemDetails.AppendChild(Details);
                            }
                        }
                        else
                        {
                            XmlElement Details = doc.CreateElement("ItemDetail");

                            XmlElement IdDetail = doc.CreateElement("Id");
                            IdDetail.InnerText = "";
                            Details.AppendChild(IdDetail);

                            XmlElement ItemId = doc.CreateElement("ItemId");
                            ItemId.InnerText = item.Id;
                            Details.AppendChild(ItemId);

                            XmlElement Price = doc.CreateElement("Price");
                            Price.InnerText = "0";
                            Details.AppendChild(Price);

                            XmlElement Quantity = doc.CreateElement("Quantity");
                            Quantity.InnerText = "0";
                            Details.AppendChild(Quantity);

                            ItemDetails.AppendChild(Details);
                        }
                        itemNew.AppendChild(ItemDetails);
                        root.ReplaceChild(itemNew, itemold);
                        doc.Save(path);
                    }
                }

                MessageBox.Show("Susscess!");
                childWindow.Close();
                foreach (Window win in Application.Current.Windows)
                {
                    if (win.Name == "MainwindowName")
                    {
                        win.DataContext = new ItemViewModel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void onExcuteDetails(object parameter)
        {
            var value = (object[])parameter;
            var wrap = (WrapPanel)value[0];
            var txtID = (TextBlock)value[1];
            Item item = ItemModel;

            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    ItemDetail detail = new ItemDetail();
                    foreach (object child in wrap.Children)
                    {
                        string childname = null;
                        if (child is FrameworkElement)
                        {
                            childname = (child as FrameworkElement).Name;
                            switch (childname)
                            {
                                case "txtPrice":
                                    detail.Price = Convert.ToDecimal((child as TextBox).Text);
                                    break;
                                case "txtQuantity":
                                    detail.Quantity = Convert.ToInt32((child as TextBox).Text);
                                    break;
                            }
                        }
                    }
                    XmlNode nodeitem = root.SelectSingleNode("Item[Id='" + item.Id + "']");
                    //node ItemDetails
                    XmlNode details = nodeitem.LastChild;
                    Random rd = new Random();
                    detail.Id = Convert.ToString(rd.Next(1, 100)) + "_detailId_" + Convert.ToString(rd.Next(1, 100));

                    //create node Itemdetail
                    XmlElement detailxml = doc.CreateElement("ItemDetail");

                    XmlElement Id = doc.CreateElement("Id");
                    Id.InnerText = detail.Id;
                    detailxml.AppendChild(Id);

                    XmlElement ItemID = doc.CreateElement("ItemId");
                    ItemID.InnerText = item.Id;
                    detailxml.AppendChild(ItemID);

                    XmlElement Price = doc.CreateElement("Price");
                    Price.InnerText = detail.Price.ToString();
                    detailxml.AppendChild(Price);

                    XmlElement Quantity = doc.CreateElement("Quantity");
                    Quantity.InnerText = detail.Quantity.ToString();
                    detailxml.AppendChild(Quantity);

                    details.AppendChild(detailxml);
                    doc.Save(path);
                }

                else
                {
                    ItemDetail detail = item.ItemDetails.SingleOrDefault(p => p.Id == txtID.Text);
                    foreach (object child in wrap.Children)
                    {
                        string childname = null;
                        if (child is FrameworkElement)
                        {
                            childname = (child as FrameworkElement).Name;
                            switch (childname)
                            {
                                case "txtPrice":
                                    detail.Price = Convert.ToDecimal((child as TextBox).Text);
                                    break;
                                case "txtQuantity":
                                    detail.Quantity = Convert.ToInt32((child as TextBox).Text);
                                    break;
                            }
                        }
                    }
                    XmlNode nodeitem = root.SelectSingleNode("Item[Id='" + item.Id + "']");
                    //node ItemDetails
                    XmlNode details = nodeitem.LastChild;

                    XmlNode detailsOld = details.SelectSingleNode("ItemDetail[Id='" + detail.Id + "']");
                    if (detailsOld != null)
                    {
                        //create node Itemdetail
                        XmlElement detailNew = doc.CreateElement("ItemDetail");

                        XmlElement Id = doc.CreateElement("Id");
                        Id.InnerText = detail.Id;
                        detailNew.AppendChild(Id);

                        XmlElement ItemID = doc.CreateElement("ItemId");
                        ItemID.InnerText = item.Id;
                        detailNew.AppendChild(ItemID);

                        XmlElement Price = doc.CreateElement("Price");
                        Price.InnerText = detail.Price.ToString();
                        detailNew.AppendChild(Price);

                        XmlElement Quantity = doc.CreateElement("Quantity");
                        Quantity.InnerText = detail.Quantity.ToString();
                        detailNew.AppendChild(Quantity);

                        details.ReplaceChild(detailNew, detailsOld);
                        doc.Save(path);
                    }
                }
                MessageBox.Show("Susscess!");
                foreach (Window win in Application.Current.Windows)
                {
                    if (win.Name == "windowDetails")
                    {
                        win.DataContext = new DialogItemViewModel(getItemforId(item.Id));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
