namespace ADDED.API.Helpers
{
    public class AffectationParam
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string Releveur { get; set; } = null;
        public int? CodLocalite { get; set; } = null;
        public string Portable { get; set; } = null ;
    }
}