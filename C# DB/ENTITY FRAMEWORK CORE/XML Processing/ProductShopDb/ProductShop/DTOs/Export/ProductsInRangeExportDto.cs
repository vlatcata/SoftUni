﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class ProductsInRangeExportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string BuyerFullName { get; set; }
    }
}
