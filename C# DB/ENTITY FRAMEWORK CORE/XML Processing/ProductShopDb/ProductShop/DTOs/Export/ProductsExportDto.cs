using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class ProductsExportDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public SoldProductsExportDto[] Products { get; set; }
    }
}
