namespace RackOfLabs.DTOs.Sorts;

public class SortField
{
    /// <summary>
    /// Field name for sorting
    /// </summary>
    public string? FieldName { get; set; }
    /// <summary>
    /// Sorting direction (as enum name or enum index)
    /// </summary>
    public SortDirection Direction { get; set; }
}