using RackOfLabs.Application.Interfaces.Services;
using RackOfLabs.Domain.Entities;
using RackOfLabs.DTOs.Device;
using RackOfLabs.DTOs.List;
using RackOfLabs.DTOs.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DevicesController : ControllerBase
{
    private readonly IDeviceService _service;
    public DevicesController(IDeviceService service)
    {
        _service = service;
    }
    
    [HttpPost("list")]
    public async Task<PaginatedResult<List<DeviceDto>>> GetList(PaginatedListRequest request)
    {
        return await _service.GetAsync<DeviceDto, Device>(request);
    }

    [HttpPost]
    public async Task<Result<DeviceDto>> Create(CreateDeviceRequest request)
    {
        return await _service.CreateAsync<DeviceDto, Device, CreateDeviceRequest>(request);
    }
    
    [HttpPut("{id}")]
    public async Task<Result<DeviceDto>> Update(UpdateDeviceRequest request, Guid id)
    {
        return await _service.UpdateAsync<DeviceDto, Device, UpdateDeviceRequest>(request, id);
    }
    
    [HttpDelete("{id}")]
    public async Task<Result> Delete(Guid id)
    {
        return await _service.DeleteAsync<Device>(id);
    }
}