using FluentValidation;
using NailsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Models.Validators
{
    public class AppointmentQueryValidator : AbstractValidator<AppointmentQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames =
            {nameof(Appointment.LastName), nameof(Appointment.MeetingDate), nameof(Appointment.Procedure.Name)};
        public AppointmentQueryValidator()
        {
            RuleFor(a => a.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(a => a.PageSize).Custom((value, context) =>
            {
                if(!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(a => a.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",",allowedSortByColumnNames)}]");
        }
    }
}
