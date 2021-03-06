using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PinewoodGrow.Models.Audit;

namespace PinewoodGrow.Models.Temp
{
    public class TempMember : Auditable
    {
        public TempMember()
        {
            MemberSituations = new HashSet<TempMemberSituation>();
            MemberDietaries = new HashSet<TempMemberDietary>();
            MemberIllnesses = new HashSet<TempMemberIllness>();
            MemberDocuments = new HashSet<TempMemberDocument>();
            MemberHouseholds = new HashSet<TempMemberHousehold>();
        }

        public bool isValid => CheckValid();








        public string FullName => FirstName + " " + LastName;

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

        public double Income => MemberSituations.Select(a=> a.SituationIncome).ToList().Sum();

		public int ID { get; set; }


		public string FirstName { get; set; }


		public string LastName { get; set; }

		/*[Required(ErrorMessage = "You cannot leave the Age blank.")]
		[Range(1, 115, ErrorMessage = "Age must be greater than 0.")]
		public int Age { get; set; }*/

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

		public DateTime? DOB { get; set; }


		public string Telephone { get; set; }

		public string Email { get; set; }

        public string Notes { get; set; }

		public bool Consent { get; set; }

	
		public int? VolunteerID { get; set; }
		public Volunteer Volunteer { get; set; }

	
		public DateTime CompletedOn { get; set; }


		public int? TempHouseholdID { get; set; }
		public TempHousehold TempHousehold { get; set; }
        public int? HouseholdID { get; set; }
        public Household Household { get; set; }


		public int? GenderID { get; set; }
		public Gender Gender { get; set; }

		public ICollection<TempMemberSituation> MemberSituations { get; set; }
        public ICollection<TempMemberDietary> MemberDietaries { get; set; }

		public ICollection<TempMemberIllness> MemberIllnesses { get; set; }
        public ICollection<TempMemberDocument> MemberDocuments { get; set; }

		public ICollection<TempMemberHousehold> MemberHouseholds { get; set; }


        private bool CheckValid()
        {
            if (!ValidateName(FirstName)) return false;
            if (!ValidateName(LastName)) return false;
            if (string.IsNullOrEmpty(Telephone)) return false;
            if (Telephone.Length > 11) return false;
            if (string.IsNullOrEmpty(Email)) return false;
            if(!string.IsNullOrEmpty(Notes)) if (Notes.Length > 2000) return false;
            if (GenderID == null || GenderID == 0) return false;
            if (DOB.GetValueOrDefault() > DateTime.Today) return false;
            var age = (DateTime.Today.Year - DOB.GetValueOrDefault().Year) -
                      ((-DOB.GetValueOrDefault().Month + DOB.GetValueOrDefault().Day) >=
                       (-DateTime.Today.Month + DateTime.Today.Day) ? 1 : 0);

            if (age > 100 || age < 18) return false; 
              


            return Consent;


        }

        private bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length > 50) return false;
            return true;
        }
	}
}

