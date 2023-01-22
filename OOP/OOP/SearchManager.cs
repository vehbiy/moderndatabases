using System.Collections.Generic;

namespace OOP
{
    public static class SearchManager
    {
        public static List<ISearchResult> Search(string keyword)
        {
            List<ISearchResult> results = new List<ISearchResult>();
            results.Add(new User());
            results.Add(new News2());
            results.Add(new Advertisement());
            return results;
        }
    }
}