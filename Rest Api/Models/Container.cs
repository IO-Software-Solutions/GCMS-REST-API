using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Models
{
    public class Container
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Volume { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Container()
        {
        }

        public Container(int id, string name, double volume, string description, string image)
        {
            Id = id;
            Name = name;
            Volume = volume;
            Description = description;
            Image = image;
        }
    }
}
