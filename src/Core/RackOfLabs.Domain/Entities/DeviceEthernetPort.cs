using RackOfLabs.Domain.Base;
#pragma warning disable CS8618

namespace RackOfLabs.Domain.Entities;

public class DeviceEthernetPort : BaseEntity
{
    /// <summary>
    /// Mac address of the device ethernet port
    /// </summary>
    public string MacAddress { get; set; } = "";
    /// <summary>
    /// Port used for device management, i.e. ILO, BMC, IPMI
    /// </summary>
    public bool ManagementPort { get; set; }
    /// <summary>
    /// Link to the device
    /// </summary>
    public virtual Device Device { get; set; }
}