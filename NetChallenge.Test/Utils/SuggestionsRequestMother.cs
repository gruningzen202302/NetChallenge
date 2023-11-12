using System;
using NetChallenge.Dto.Input;

namespace NetChallenge.Test.Utils
{
    public static class SuggestionsRequestMother
    {
        public static SuggestionsRequest Default => new SuggestionsRequest
        {
            MinCapacity = 1,
            NeigborHoodPrefference = null,
            FacilitiesEssentials = Array.Empty<string>()
        };

        public static SuggestionsRequest WithCapacityNeeded(this SuggestionsRequest request, int capacity)
        {
            request.MinCapacity = capacity;
            return request;
        }

        public static SuggestionsRequest WithPreferedNeigborHood(this SuggestionsRequest request, string neighborhood)
        {
            request.NeigborHoodPrefference = neighborhood;
            return request;
        }

        public static SuggestionsRequest WithResourcesNeeded(this SuggestionsRequest request, params string[] resources)
        {
            request.FacilitiesEssentials = resources;
            return request;
        }
    }
}