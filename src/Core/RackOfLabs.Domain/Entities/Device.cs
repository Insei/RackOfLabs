using RackOfLabs.Domain.Base;
using RackOfLabs.Domain.Enums;
#pragma warning disable CS8618

namespace RackOfLabs.Domain.Entities;

public class Device : BaseEntity
{
    /// <summary>
    /// Name of the device
    /// </summary>
    public string Name { get; set; }  = "";
    /// <summary>
    /// Serial number of the device
    /// </summary>
    public string Serial { get; set; } = "";
    /// <summary>
    /// Current power state of the device (last saved)
    /// </summary>
    public DevicePowerState PowerState { get; set; }
    /// <summary>
    /// Last device status change date and time
    /// </summary>
    public DateTime PowerStateModified { get; set; }
    /// <summary>
    /// Boot device (last saved)
    /// </summary>
    public BootDevice BootDevice { get; set; }
    /// <summary>
    /// Current Boot stage index
    /// </summary>
    public int BootStageIndex { get; set; } = 0;
    /// <summary>
    /// The template used for this device
    /// </summary>
    public virtual DeviceTemplate? Template { get; set; }
}