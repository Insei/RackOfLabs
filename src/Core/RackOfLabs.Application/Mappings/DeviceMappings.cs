using AutoMapper;
using RackOfLabs.Domain.Entities;
using RackOfLabs.DTOs.Device;

namespace RackOfLabs.Application.Mappings;

public class DeviceMappings  : Profile
{
    public DeviceMappings()
    {
        CreateMap<Device, CreateDeviceRequest>().ReverseMap();
        CreateMap<Device, UpdateDeviceRequest>().ReverseMap();
        CreateMap<Device, DeviceDto>().ReverseMap();
    }
}