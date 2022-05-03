using Microsoft.AspNetCore.Authorization;
using NailsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NailsAPI.Authorization
{
    public class MinimumAppointmentsRequirementHandler : AuthorizationHandler<MinimumAppointmentsRequirement>
    {
        private readonly NailsDbContext _dbContext;
        public MinimumAppointmentsRequirementHandler(NailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAppointmentsRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var createdAppointmentsCount = _dbContext
                .Appointments
                .Count(a => a.CreatedById == userId);

            if(createdAppointmentsCount >= requirement.MinimumAppointments)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
