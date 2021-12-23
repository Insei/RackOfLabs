using RackOfLabs.Domain.Entities;
using RackOfLabs.Domain.Enums;

namespace RackOfLabs.Application.Interfaces.Management;

public interface IDeviceManagementService
{
    /// <summary>
    /// Power on device
    /// </summary>
    /// <param name="id">Device ID</param>
    /// <returns></returns>
    Task PowerOn(Guid id);
    /// <summary>
    /// Power off device
    /// </summary>
    /// <param name="id">Device ID</param>
    /// <returns></returns>
    Task PowerOff(Guid id);
    /// <summary>
    /// Reboot device
    /// </summary>
    /// <param name="id">Device ID</param>
    /// <returns></returns>
    Task Reboot(Guid id);
    /// <summary>
    /// Get current power state from power controller(s).
    /// </summary>
    /// <param name="id">Device ID</param>
    /// <returns></returns>
    Task<DevicePowerState> GetCurrentPowerState(Guid id);
    /// <summary>
    /// Set boot device
    /// </summary>
    /// <param name="id">Device ID</param>
    /// <param name="bootDevice">Boot device</param>
    /// <returns></returns>
    Task SetBootDevice(Guid id, BootDevice bootDevice);
    /// <summary>
    /// Get current boot device
    /// </summary>
    /// <param name="id">Device ID</param>
    /// <returns></returns>
    Task<BootDevice> GetCurrentBootDevice(Guid id);
}