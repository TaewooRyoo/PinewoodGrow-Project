﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinewoodGrow.Models.Temp
{
    public class TempMember
    {
		public TempMember()
		{
			MemberSituations = new HashSet<TempMemberSituation>();
			MemberDietaries = new HashSet<TempMemberDietary>();
			MemberIllnesses = new HashSet<TempMemberIllness>();
			MemberDocuments = new HashSet<TempMemberDocument>();
			MemberHouseholds = new HashSet<TempMemberHousehold>();
		}


		public string FullName => FirstName + " " + LastName;

		public string TelephoneFormatted
		{
			get
			{
				if (Telephone.Length == 10)
					return "(" + Telephone.Substring(0, 3) + ") " + Telephone.Substring(3, 3) + "-" + Telephone[6..];
				return Telephone.Substring(0, 1) + "(" + Telephone.Substring(1, 3) + ") " + Telephone.Substring(4, 3) + "-" + Telephone[7..];
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

		[DataType(DataType.Currency)]
		public double IncomeTotal
		{
			get
			{
				double incomeTotal = Income + MemberSituations.Select(a => a.SituationIncome).ToList().Sum();

				return incomeTotal;
			}
		}

		public int ID { get; set; }


		public string FirstName { get; set; }


		public string LastName { get; set; }

		/*[Required(ErrorMessage = "You cannot leave the Age blank.")]
		[Range(1, 115, ErrorMessage = "Age must be greater than 0.")]
		public int Age { get; set; }*/


		public DateTime? DOB { get; set; }


		public string Telephone { get; set; }

		public string Email { get; set; }


		public double Income { get; set; }


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
	}
}
