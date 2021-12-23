using RackOfLabs.Domain.Enums;
#pragma warning disable CS8618

namespace RackOfLabs.Domain.Entities;

public class Rent
{
    /// <summary>
    /// Name of the rent
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Close DateTime UTC for rent
    /// </summary>
    public DateTime Closed { get; set; }
    /// <summary>
    /// Rent status
    /// </summary>
    public RentStatus Status { get; set; }
    /// <summary>
    /// Rented device
    /// </summary>
    public virtual Device Device { get; set; }
}