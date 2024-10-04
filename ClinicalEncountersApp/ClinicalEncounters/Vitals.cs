using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalEncounters
{
    public class Vitals
    {
        public List <string?> BloodPressures { get; set; }
        public List <string?> HeartRate { get; set; }
        public List <string?> Temperature { get; set; }
        public List <string?> RespiratoryRate { get; set;}
    }
}
