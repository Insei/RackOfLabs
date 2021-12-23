using RackOfLabs.Domain.Base;
#pragma warning disable CS8618

namespace RackOfLabs.Domain.Entities;

public class BootStage : BaseEntity
{
    /// <summary>
    /// Name of the boot stage
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Index number; value only can be > 0
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// Device template 
    /// </summary>
    public virtual DeviceTemplate Template { get; set; }
}