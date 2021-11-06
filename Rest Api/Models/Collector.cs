using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Models
{
    public class Collector : User
    {
        public ICollection<Garbage> Garbages { get; set; }

        public Collector() : base()
        {
        }

        public Collector(int id, string firstname, string middlename, string lastname, string address, string phone, string email, string password, bool confirmed) : base(id, firstname, middlename, lastname, address, phone, email, password, confirmed)
        {
        }

        public void Accept(Garbage garbage)
        {
            garbage.Accept(this);
        }

        public void ScheduleCollection(Garbage garbage, DateTime collectionTime)
        {
            garbage.ScheduleCollection(collectionTime);
        }

        public void ConfirmCollection(Garbage garbage)
        {
            garbage.CollectorConfirmed = true;
            garbage.ConfirmCollection();
        }
    }
}
