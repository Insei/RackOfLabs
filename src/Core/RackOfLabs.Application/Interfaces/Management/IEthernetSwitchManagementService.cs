using RackOfLabs.Domain.Entities;

namespace RackOfLabs.Application.Interfaces.Management;

public interface IEthernetSwitchManagementService
{
    /// <summary>
    /// Power on POE on port
    /// </summary>
    /// <param name="port"></param>
    void PoePowerOn(EthernetSwitchPort port);
    /// <summary>
    /// Power off POE on port
    /// </summary>
    /// <param name="port">Switch port</param>
    void PoePowerOff(EthernetSwitchPort port);
    /// <summary>
    /// Set default VLAN on the port
    /// </summary>
    /// <param name="port">Switch port</param>
    /// <param name="vlan">VLAN ID</param>
    void SetDefault(EthernetSwitchPort port, int vlan);
    /// <summary>
    /// Set tagged VLAN on the switch port
    /// </summary>
    /// <param name="port">Switch port</param>
    /// <param name="vlan">VLAN ID</param>
    void SetTagged(EthernetSwitchPort port, int vlan);
}