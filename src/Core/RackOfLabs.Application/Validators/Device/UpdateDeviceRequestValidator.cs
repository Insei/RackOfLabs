using FluentValidation;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.DTOs.Device;

namespace RackOfLabs.Application.Validators.Device;

public class UpdateDeviceRequestValidator : AbstractValidator<UpdateDeviceRequest>
{
    private readonly IGenericRepositoryAsync _repository;

    public UpdateDeviceRequestValidator(IGenericRepositoryAsync repository)
    {
        _repository = repository;

        RuleFor(d => d.Serial)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
    }
}