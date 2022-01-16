using FluentValidation;
using RackOfLabs.Application.Interfaces.Generic;
using RackOfLabs.DTOs.List;

namespace RackOfLabs.Application.Validators;

public class PaginatedListRequestValidator : AbstractValidator<PaginatedListRequest>
{

    public PaginatedListRequestValidator()
    {
        RuleFor(d => d.Search)
            .MinimumLength(3).WithMessage("Search string must contain at least 3 characters.");
    }
}