using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Rubtsova_7zad_7var
{
    public class Material
    {
        public string MaterialName { get; set; }
        public string WoodType { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; } // Краткое описание
        public string PaymentType { get; set; } // Вид оплаты
        public string RequiresProcessing { get; set; } // Необходимость обработки
    }
}