using RackOfLabs.Domain.Base;

namespace RackOfLabs.Domain.Entities;

public class DeviceTemplate : TemplateEntity
{
    /// <summary>
    /// Unique name of the template
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Device model
    /// </summary>
    public string Model { get; set; } = "";
    /// <summary>
    /// Device manufacturer
    /// </summary>
    public string Manufacturer { get; set; } = "";
    /// <summary>
    /// Device cpu architecture
    /// </summary>
    public string Arch { get; set; } = "";
}