using FluentValidation;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.DTOs.Device;

namespace RackOfLabs.Application.Validators.Device;

public class CreateDeviceRequestValidator : AbstractValidator<CreateDeviceRequest>
{
    private readonly IGenericRepositoryAsync _repository;
    
    public CreateDeviceRequestValidator(IGenericRepositoryAsync repository)
    {
        _repository = repository;

        RuleFor(d => d.Serial)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .MustAsync(IsUniqueSerial).WithMessage("Device with this {PropertyName} already exists.")
            .WithErrorCode("Test");
    }

    private async Task<bool> IsUniqueSerial(string serial, CancellationToken cancellationToken)
    {
        return !(await _repository.ExistsAsync<Domain.Entities.Device>(d => serial.Trim() == d.Serial.Trim(), cancellationToken));
    }
}