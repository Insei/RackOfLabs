using AutoMapper;
using RackOfLabs.Application.Exceptions;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.Application.Interfaces.Services;
using RackOfLabs.Domain.Entities;
using RackOfLabs.DTOs.Device;

namespace RackOfLabs.Application.Services;

public class DeviceService : GenericEntityService, IDeviceService
{
    public DeviceService(IGenericRepositoryAsync repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    /// <summary>
    /// Check that serial number is unique before update
    /// </summary>
    protected override async Task ValidateUpdateRequestAsync<TUpdateReq>(TUpdateReq updateRequest, Guid id)
    {
        var device = updateRequest as UpdateDeviceRequest;
        var exist = await Repository.ExistsAsync<Device>(d => device != null 
                                            && !d.Removed && d.Serial.Trim().Equals(device.Serial.Trim())
                                            && d.Id != id);
        if (exist)
            throw new EntityAlreadyExistsException("Device with this Serial already exist");

    }
}