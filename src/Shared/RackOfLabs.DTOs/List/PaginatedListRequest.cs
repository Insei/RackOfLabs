using RackOfLabs.DTOs.Sorts;

namespace RackOfLabs.DTOs.List;

public class PaginatedListRequest
{
    public PageInfo Info { get; set; }
    public SortField Sort { get; set; }
    public string Search { get; set; }
    
    public PaginatedListRequest()
    {
        Info = new PageInfo();
        Sort = new SortField();
        Search = "";
    }
}