using Rest_Api.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Models
{
    public class Garbage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public ICollection<Container> Containers { get; set; }

        [Required]
        public Resident Resident { get; set; }

        public Collector Collector { get; set; }

        [Required]
        public Status.Request Status { get; set; }

        [Required]
        public DateTime TimeRequested { get; set; }

        public DateTime CollectionTime { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        public bool ResidentConfirmed { get; set; }

        public bool CollectorConfirmed { get; set; }

        public Garbage()
        {
            Status = Modules.Status.Request.Pending;
            TimeRequested = DateTime.Now;
            TimeRequested = DateTime.Now.AddDays(1);
            LastUpdated = DateTime.Now;
            ResidentConfirmed = false;
            CollectorConfirmed = false;
        }

        public Garbage(int id, ICollection<Container> containers, Resident resident, Collector collector, Status.Request status, DateTime timeRequested, DateTime collectionTime, DateTime lastUpdated)
        {
            Id = id;
            Containers = containers;
            Resident = resident;
            Collector = collector;
            Status = status;
            TimeRequested = timeRequested;
            CollectionTime = collectionTime;
            LastUpdated = lastUpdated;
            ResidentConfirmed = false;
            CollectorConfirmed = false;
        }

        public void Accept(Collector collector)
        {
            Collector = collector;
            Status = Modules.Status.Request.Accepted;
            LastUpdated = DateTime.Now;
        }

        public void ScheduleCollection(DateTime collectionTime)
        {
            Status = Modules.Status.Request.Assigned;
            CollectionTime = collectionTime;
            LastUpdated = DateTime.Now;
        }

        public void Cancel()
        {
            Status = Modules.Status.Request.Cancelled;
            LastUpdated = DateTime.Now;
        }

        public void ConfirmCollection()
        {
            if(ResidentConfirmed && CollectorConfirmed)
            {
                Status = Modules.Status.Request.Collected;
                LastUpdated = DateTime.Now;
            }
        }
    }
}
