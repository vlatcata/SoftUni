using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public string PurchaseType { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"^([A-Z0-9]{4})\\-([A-Z0-9]{4})\\-([A-Z0-9]{4})$")]
        public string Key { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(@"^(\\d{4})\\s(\\d{4})\\s(\\d{4})\\s(\\d{4})$")]
        public string CardNumber { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}
