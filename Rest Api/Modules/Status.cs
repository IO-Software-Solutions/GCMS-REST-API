using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Modules
{
    public class Status
    {
        public enum Request
        {
            Pending = 1,
            Accepted,
            Assigned,
            Collected,
            Rejected,
            Overdue,
            Cancelled
        }
    }
}
