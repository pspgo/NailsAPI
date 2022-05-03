using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NailsAPI.Authorization
{
    public class MinimumAppointmentsRequirement : IAuthorizationRequirement//marker pozwalajacy .net rozpoznac ze to requirement w autoryzacji
    {
        public int MinimumAppointments { get; }
        public MinimumAppointmentsRequirement(int minimumAppointments)
        {
            MinimumAppointments = minimumAppointments;
        }
    }
}
