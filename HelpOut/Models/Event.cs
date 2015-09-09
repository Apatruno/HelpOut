using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOut.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [StringLength(150, ErrorMessage = "Name of Event cannot be longer than 150 characters.")]
        [Display(Name = "Event Name")]
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        [StringLength(500, ErrorMessage = "Event description exceeds 500 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //adding an image.

        //public string image { get; set; }


        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters ")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(30, ErrorMessage = "Enter a valid City")]
        [Display(Name = "City")]
        public string City { get; set; }



        [StringLength(20, ErrorMessage = "Enter a valid State")]
        [Display(Name = "State")]
        public string State { get; set; }

        [MaxLength(9)]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }


        [MaxLength(20)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        //[Required]
        //[StringLength(25, ErrorMessage = "Give your first Name alone ")]





        public string getAddress()
        {
            string FullAddress = Address + ", " + City + ", " + State + ", " + ZipCode;
            return FullAddress;
        }

        //foreign key for our User w/ role organization that made the event
        [ForeignKey("Organization")]

        public string OrganizationID { get; set; }

        //navigation property
        //[ForeignKey("OrganizationID")] //workaround for the foreign key mapping issue
        public virtual ApplicationUser Organization { get; set; }
        public virtual ICollection<ApplicationUser> Attendees { get; set; }

        public virtual ICollection<FilePath> FilePaths { get; set; }
    }
}

