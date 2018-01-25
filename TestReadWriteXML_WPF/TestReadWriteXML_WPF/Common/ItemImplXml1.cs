using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestReadWriteXML_WPF.Entity;

namespace TestReadWriteXML_WPF.Common
{
    public class ItemImplXml1
    {
        XmlDocument doc = new XmlDocument();
        XmlElement elm;
        string path = "D:/WORKING_Hung/GITHUB/QLMN_WPF_Project/TestReadWriteXML_WPF/TestReadWriteXML_WPF/DATA.xml";

        public ObservableCollection<Item> GetListItem()
        {
            ObservableCollection<Item> listItem = new ObservableCollection<Item>();
            try
            {
                ObservableCollection<ItemDetail> listDetails;
                Item item;
                ItemDetail detail;
                doc.Load(path);
                foreach (XmlNode node in doc.DocumentElement)
                {
                    item = new Item();

                    item.Id = node.Attributes[0].InnerText;
                    item.Name = node["Name"].InnerText;
                    item.Unit = node["Unit"].InnerText;
                    item.CreateDate = Convert.ToDateTime(node["CreateDate"].InnerText);
                    if (node.FirstChild.InnerText == item.Id)
                    {
                        listDetails = new ObservableCollection<ItemDetail>();
                        foreach (XmlNode nodeDetail in node.LastChild.ChildNodes)
                        {
                            detail = new ItemDetail();
                            detail.Id = nodeDetail.Attributes[0].InnerText;
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
                    listItem.Add(item);
                }
                return listItem;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

    }
}
