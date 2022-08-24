using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerCSV.Models
{
    public class ClipertDataCSV
    {
        [CsvColumn(Name = "POLIZA", FieldIndex = 1)]
        public string policy { get; set; }

        [CsvColumn(Name = "PRIMATOTAL", FieldIndex = 2, OutputFormat = "C")]
        public decimal totalPremium { get; set; }

        [CsvColumn(Name = "REFERENCIA", FieldIndex = 9)]
        public string reference { get; set; }

        [CsvColumn(Name = "NUMCERT", FieldIndex = 10)]
        public string certificate { get; set; }

        [CsvColumn(Name = "NUMFACT", FieldIndex = 11)]
        public string invoice { get; set; }

        [CsvColumn(Name = "FECHAENVIOASE", FieldIndex = 12, OutputFormat = "dd-MM-yyyy")]
        public DateTime issueDate { get; set; }

        [CsvColumn(Name = "CENTROEMISOR", FieldIndex = 13)]
        public string emitterCenter { get; set; }
    }
}
