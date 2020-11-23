namespace Nager.HetznerDns.Models
{
    public class Pagination
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public int LastPage { get; set; }
        public int TotalEntries { get; set; }
    }
}
