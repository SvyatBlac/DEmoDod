using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Material
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int MinQuantity { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public decimal TotalCost { get; set; }
        public int PackageQuantity { get; set; } // Новое свойство
        public decimal MinOrderCost { get; set; } // Новое свойство

    }

}
