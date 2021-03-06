using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PinewoodGrow.Models.Audit;

namespace PinewoodGrow.Models
{
    public class Receipt : Auditable
    {
        public Receipt()
        {
            Products = new HashSet<ReceiptProduct>();
        }

        public int ID { get; set; }


        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        [Range(0.0, 9999, ErrorMessage = "Income must be between $0 and $9999.")]
        public double Total { get; set; }

        [Display(Name = "SubTotal")]
        [DataType(DataType.Currency)]
        [Range(0.0, 9999, ErrorMessage = "SubTotal must be between $0 and $9999.")]
        public double SubTotal { get; set; }


        [Display(Name = "Completed On")]
        [Required(ErrorMessage = "You cannot leave the Completed On blank.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CompletedOn { get; set; }

        [Display(Name = "Members")]
        [Required(ErrorMessage = "You cannot leave Members blank")]
        public int MemberID { get; set; }
        public Member Member { get; set; }

        [Display(Name = "Household")]
        [Required(ErrorMessage = "You cannot leave Household blank")]
        public int HouseholdID { get; set; }
        public Household Household { get; set; }

        [Display(Name = "Volunteer")]
        [Required(ErrorMessage = "You cannot leave the Completed By blank.")]
        public int VolunteerID { get; set; }
        public Volunteer Volunteer { get; set; }

        [Display(Name = "Payment")]
        [Required(ErrorMessage = "Please Select a Payment Method")]
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }

        public ICollection<ReceiptProduct> Products { get; set; }

        //public ICollection<Invoice> Invoices { get; set; }
    }
}
