using System.Collections.Generic;

namespace NetChallenge.Dto.Input
{
    public class SuggestionsRequest
    {
        public int MinCapacity { get; set; }
        public string NeigborHoodPrefference { get; set; }
        public IEnumerable<string> FacilitiesEssentials { get; set; }
    }
}