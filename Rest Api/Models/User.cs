using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        public User()
        {
        }

        public User(int id, string firstname, string middlename, string lastname, string address, string phone, string email, string password, bool confirmed)
        {
            Id = id;
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Address = address;
            Phone = phone;
            Email = email;
            Password = password;
            Confirmed = confirmed;
        }
    }
}
