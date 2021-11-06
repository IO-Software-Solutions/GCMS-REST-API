using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Models
{
    public class Resident : User
    {
        public ICollection<Garbage> Garbages { get; set; }

        public Resident() : base()
        {
        }

        public Resident(int id, string firstname, string middlename, string lastname, string address, string phone, string email, string password, bool confirmed) : base(id, firstname, middlename, lastname, address, phone, email, password, confirmed)
        {
        }

        public void CancelRequest(Garbage garbage)
        {
            garbage.Cancel();
        }

        public void ConfirmCollection(Garbage garbage)
        {
            garbage.ResidentConfirmed = true;
            garbage.ConfirmCollection();
        }
    }
}
