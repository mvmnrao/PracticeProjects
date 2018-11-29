using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndDataStructures
{
    public class SelectManyOnEnumerable
    {
        IEnumerable<int> groupIds = new int[] { 1, 2, 4, 3 };
        IEnumerable<string> qualityLevels = new string[] { "HD", "UHD" };

        public IEnumerable<string> SelectManyAndConcatDifferentEnumerableLists()
        {
            return groupIds.SelectMany(groupId => qualityLevels, (g, q) => string.Format("{0}_{1}", g, q)).ToList();
        }
    }
}
