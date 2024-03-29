﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.DTOs.Export
{
    [XmlType("Category")]
    public class CategoryExportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
