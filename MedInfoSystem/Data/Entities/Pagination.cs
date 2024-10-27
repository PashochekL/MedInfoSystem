namespace MedInfoSystem.Data.Entities
{
    public class Pagination
    {
        public int Size { get; set; }
        public int Count { get; set; }
        public int Current { get; set; }

        public Pagination(int count, int pageNumber, int pageSize)
        {
            Size = pageSize;
            Count = (int)Math.Ceiling(count / (double)pageSize); ;
            Current = pageNumber;
        }

        //public bool HasPreviousPage => PageNumber > 1;

        //public bool HasNextPage => PageNumber < TotalPages;
    }
}
