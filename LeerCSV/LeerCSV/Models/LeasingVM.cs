using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerCSV.Models
{
    public class LeasingVM
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        
            
            public string paymentFolio { get; set; }
            public string bank { get; set; }
            public string policy { get; set; }
            public string certificate { get; set; }
            public string invoice { get; set; }
            public DateTime issueDate { get; set; }
            public string emitterCenter { get; set; }
            public DateTime infoDate { get; set; }
        


    }
}
