using RackOfLabs.DTOs.Interfaces;

namespace RackOfLabs.DTOs.Device;

public class UpdateDeviceRequest : IRequest
{
    public string Serial { get; set; } = "";
}