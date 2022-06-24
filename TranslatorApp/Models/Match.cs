using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorApp.Models
{
    public class Match
    {
        public string id { get; set; }
        public string segment { get; set; }
        public string translation { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string quality { get; set; }
        public object reference { get; set; }
        //public int match { get; set; }
    }
}
