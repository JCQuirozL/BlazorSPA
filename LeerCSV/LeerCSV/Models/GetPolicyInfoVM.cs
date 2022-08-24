using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerCSV.Models
{
    public class GetPolicyInfoVM
    {
        [CsvColumn(Name = "POLIZA", FieldIndex = 1)]
        public string Policy { get; set; } = null!;

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
