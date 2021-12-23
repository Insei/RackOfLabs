using RackOfLabs.DTOs.List;

namespace RackOfLabs.DTOs.Results;

public class Pagination
{
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public Pagination(int currentPage, int pageSize, int totalPages, int totalCount)
    {
        TotalPages = totalPages;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public Pagination()
    {
        TotalPages = 0;
        TotalCount = 0;
        CurrentPage = 1;
        PageSize = 10;
    }

    public static Pagination Generate(PaginatedListRequest request, int totalCount)
    {
        var page = request.Info.PageNumber > 0 ? request.Info.PageNumber : 1;
        var pageSize = request.Info.PageSize > 0 ? request.Info.PageSize : 10;
        var pagination = new Pagination()
        {
            CurrentPage = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize)
        };
        return pagination;
    }
}

public class PaginatedResult<T> : Result<T>
{
    public Pagination Pagination { get; set; }

    public PaginatedResult()
    {
        Pagination = new Pagination();
    }
    
    public PaginatedResult(T data, int currentPage, int pageSize, int totalPages, int totalCount)
    {
        Pagination = new Pagination(currentPage, pageSize, totalPages, totalCount);
        Data = data;
    }
}