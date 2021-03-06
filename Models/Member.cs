using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PinewoodGrow.Models.Audit;

namespace PinewoodGrow.Models
{
	public class Member : Auditable, IValidatableObject
	{
		public Member()
		{
			MemberSituations = new HashSet<MemberSituation>();
			MemberDietaries = new HashSet<MemberDietary>();
			MemberIllnesses = new HashSet<MemberIllness>();
			MemberDocuments = new HashSet<MemberDocument>();
			MemberHouseholds = new HashSet<MemberHousehold>();
		}

		[Display(Name = "Member")]
		public string FullName => FirstName + " " + LastName;

        [Display(Name = "Phone")]
		public string TelephoneFormatted
		{
			get
			{
				if (Telephone.Length == 10)
					return "(" + Telephone.Substring(0, 3) + ") " + Telephone.Substring(3, 3) + "-" + Telephone[6..];
                return Telephone.Substring(0, 1) + "(" + Telephone.Substring(1, 3) + ") " + Telephone.Substring(4, 3) + "-" + Telephone[7..];
			}
		}
        [DataType(DataType.Currency)]
		public double Income => MemberSituations.Select(a=> a.SituationIncome).ToList().Sum();

		public string Age
		{
			get
			{
				DateTime today = DateTime.Today;
				int? a = today.Year - DOB?.Year
					- ((today.Month < DOB?.Month || (today.Month == DOB?.Month && today.Day < DOB?.Day) ? 1 : 0));
				return a?.ToString(); /*Note: You could add .PadLeft(3) but spaces disappear in a web page. */
			}
		}

		[Display(Name = "Age (DOB)")]
		public string AgeSummary
		{
			get
			{
				string ageSummary = "Unknown";
				if (DOB.HasValue)
				{
					ageSummary = Age + " (" + String.Format("{0:yyyy-MM-dd}", DOB) + ")";
				}
				return ageSummary;
			}
		}


		public int ID { get; set; }

		[Display(Name = "First Name")]
		[Required(ErrorMessage = "You cannot leave the First Name blank.")]
		[StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters long.")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "You cannot leave the Last Name blank.")]
		[StringLength(50, ErrorMessage = "Last Name cannot be more than 50 characters long.")]
		public string LastName { get; set; }

		/*[Required(ErrorMessage = "You cannot leave the Age blank.")]
		[Range(1, 115, ErrorMessage = "Age must be greater than 0.")]
		public int Age { get; set; }*/

		[Display(Name = "Date of Birth")]
		[DataType(DataType.Date)]
		
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? DOB { get; set; }

		[Required(ErrorMessage = "You cannot leave the Telephone blank.")]
		[StringLength(11, ErrorMessage = "Phone number By cannot be more than 11 characters long.")]
		[DataType(DataType.PhoneNumber)]
		public string Telephone { get; set; }

		[Required(ErrorMessage = "You cannot leave the Email blank.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        

		[StringLength(2000, ErrorMessage = "Member Notes cannot be more than 2000 characters long.")]
		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }

		[Required(ErrorMessage = "You cannot leave the Consent unselected.")]
		public bool Consent { get; set; }

		/*[Display(Name = "Completed By")]
		[Required(ErrorMessage = "You cannot leave the Completed By blank.")]
		public int VolunteerID { get; set; }
		public Volunteer Volunteer { get; set; }*/

		[Display(Name = "Completed On")]
		[Required(ErrorMessage = "You cannot leave the Completed On blank.")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime CompletedOn { get; set; }

		[Display(Name = "Household")]
		[Required(ErrorMessage = "You cannot leave Household blank")]
		public int HouseholdID { get; set; }
		public Household Household { get; set; }

		[Display(Name = "Gender")]
		[Required(ErrorMessage = "You cannot leave Gender blank")]
		public int GenderID { get; set; }
		public Gender Gender { get; set; }

		[Display(Name = "Member Situation")]
		[Required(ErrorMessage = "You cannot leave Member Situation blank")]
		public ICollection<MemberSituation> MemberSituations { get; set; }

		[Display(Name = "Dietary Restrictions")]
		public ICollection<MemberDietary> MemberDietaries { get; set; }

		[Display(Name = "Illnesses")]
		public ICollection<MemberIllness> MemberIllnesses { get; set; }

		[Display(Name = "Documents")]
		public ICollection<MemberDocument> MemberDocuments { get; set; }

		[Display(Name = "Member Households")]
		public ICollection<MemberHousehold> MemberHouseholds { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (DOB.GetValueOrDefault() > DateTime.Today)
			{
				yield return new ValidationResult("Date of Birth cannot be in the future.", new[] { "DOB" });
			}
		}
	}
}
