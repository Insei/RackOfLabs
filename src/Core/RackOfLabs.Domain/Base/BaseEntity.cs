namespace RackOfLabs.Domain.Base;

public class BaseEntity
{
    /// <summary>
    /// Id of the entity
    /// </summary>
    public virtual Guid Id { get; set; }
    /// <summary>
    /// Removed flag
    /// </summary>
    public bool Removed { get; set; }
    /// <summary>
    /// Created at DateTime UTC
    /// </summary>
    public DateTime Created { get; set; }
    /// <summary>
    /// Create by user ID
    /// </summary>
    public virtual Guid CreatedBy { get; set; }
    /// <summary>
    /// Last modified DateTime UTC
    /// </summary>
    public DateTime? LastModified { get; set; }
    /// <summary>
    /// Last modified by user ID
    /// </summary>
    public Guid? LastModifiedBy { get; set; }
}