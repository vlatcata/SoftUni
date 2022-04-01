using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"\d{4} \d{4} \d{4} \d{4}")]
        public string Number { get; set; }

        [Required]
        [MaxLength(3)]
        [JsonProperty("CVC")]
        [RegularExpression(@"^(\\d{3})$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
