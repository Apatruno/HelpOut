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
        [RegularExpression(@"^[!.,'?a-zA-Z]+(?:[\s-][.,'?a!a-zA-Z]+)*$")]
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        [StringLength(500, ErrorMessage = "Event description exceeds 500 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters ")]
        [Display(Name = "Address")]
        [RegularExpression(@"^[a-zA-Z0-9]+(?:[\s-][!a-zA-Z]+)*$")]
        public string Address { get; set; }

        [StringLength(30, ErrorMessage = "Enter a valid City")]
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Enter a valid State Code")]
        [Display(Name = "State")]
        [RegularExpression(@"^(?:(A[KLRZ]|C[AOT]|D[CE]|FL|GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|P[AR]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY]))$")]
        public string State { get; set; }

        [MaxLength(9, ErrorMessage = "Enter a Us zipcode")]
        [Display(Name = "ZipCode")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$")]
        public string ZipCode { get; set; }






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

