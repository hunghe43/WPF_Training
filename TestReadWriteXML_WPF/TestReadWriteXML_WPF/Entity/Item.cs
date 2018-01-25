using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReadWriteXML_WPF.Entity
{
    public class Item
    {
        public Item()
        {
            ItemDetails = new HashSet<ItemDetail>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public DateTime CreateDate { get; set; }       

        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
    }
}
