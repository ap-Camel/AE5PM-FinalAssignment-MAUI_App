using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace TranslatorApp.Models
{
    [Table("Translations")]
    public class Translation
    {
        [MaxLength(250)]  
        public string translatefrom { get; set; }

        [MaxLength(250)]
        public string translateTo { get; set; }
    }
}
