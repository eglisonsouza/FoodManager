namespace FoodManager.Core.Mediator.Results
{
    public class PageResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalResults { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
