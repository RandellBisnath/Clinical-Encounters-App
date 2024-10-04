using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalEncounters
{
    public class VitalManager
    {
        public VitalManager() { }
        public List<string?> checkMatches(Regex pattern, string noteContent)
        {
            MatchCollection matches = pattern.Matches(noteContent);
            List<string?> vitals = new List<string?>();
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    //lstVitals.Items.Add(match);
                    vitals.Add(match.ToString());
                }
            }
            return vitals;
        }
        public List<int> checkBloodPressure(List<string?> bloodPressure)
        {
            List<int> bp = new List<int>();
            foreach (var item in bloodPressure)
            {
                string[] nums = item.Split('/');
                nums[0] = nums[0].Remove(0, 3);
                nums[0] = nums[0].Trim();

                bp.Add(int.Parse(nums[0]));
                bp.Add(int.Parse(nums[1]));
            }
            return bp;
        }


        public List<int> checkHRAndRR(List<string?> vital)
        {
            List<int> v = new List<int>();
            foreach (var item in vital)
            {
                string nums = item.Remove(0,3);
                nums= nums.Trim();
                v.Add(int.Parse(nums));

            }
            return v;
        }
        public List<double> checkTemp(List<string?> temp)
        {
            List<double> t = new List<double>();
            foreach (var item in temp)
            {
                string nums = item.Remove(0,3);
                nums = nums.Trim();
                t.Add(double.Parse(nums));
            }
            return t;
        }
    }
}
