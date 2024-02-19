namespace ADDED.API.Helpers
{
    public class IndexParam
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int? Ordre { get; set; }
        public int? Tournee { get; set; }
    }
}