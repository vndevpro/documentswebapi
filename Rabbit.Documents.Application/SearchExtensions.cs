namespace Rabbit.Documents.Application
{
    public static class SearchExtensions
    {
        /// <summary>
        /// Convert a search input into FullTextSearch terms by adding * into search text. Eg "IT books" will be converted to "*IT* *books*".
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public static string ConvertToFtsTerms(this string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return string.Empty;
            }

            var normalizedSearchText = searchText.Trim().Replace("  ", " ");

            return $"*{normalizedSearchText.Replace(" ", "* *")}*";
        }
    }
}
