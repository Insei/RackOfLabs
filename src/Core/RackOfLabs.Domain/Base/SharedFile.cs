namespace RackOfLabs.Domain.Base;

public class SharedFile : BaseEntity
{
    /// <summary>
    /// The path to the file
    /// </summary>
    public string Path { get; set; } = "";
    /// <summary>
    /// File name with extension
    /// </summary>
    public string Name { get; set; } = "";
}