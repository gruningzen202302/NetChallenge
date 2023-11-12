using System.Collections.Generic;

namespace NetChallenge.Dto.Input
{
    public class SuggestionsRequest
    {
        /// <summary>
        /// The minimum Capacity needed for the rental. <br/>
        /// A greater capacity can be suggested in ascending order
        /// because It is preffered to give the priority to the offices with a 
        /// MaxCapaity equal or barely greater than the MinCapacity suggested,
        /// leaving greater offices for other rentals
        /// </summary>
        public int MinCapacity { get; set; }
        public string NeigborHoodPrefference { get; set; }
        public IEnumerable<string> FacilitiesEssentials { get; set; }
    }
}