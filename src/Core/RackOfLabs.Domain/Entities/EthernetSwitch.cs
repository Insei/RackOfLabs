using RackOfLabs.Domain.Base;
#pragma warning disable CS8618

namespace RackOfLabs.Domain.Entities;

public class EthernetSwitch : BaseEntity
{
    /// <summary>
    /// Name of the device Switch
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Switch template
    /// </summary>
    public virtual EthernetSwitchTemplate Template { get; set; }
}