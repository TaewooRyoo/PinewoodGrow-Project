using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PinewoodGrow.Models.Audit;

namespace PinewoodGrow.Models.Temp
{
    public class TempMemberSituation : Auditable
    {

        public int ID { get; set; }
        public int SituationID { get; set; }
        public Situation Situation { get; set; }

        public int MemberID { get; set; }
        public TempMember Member { get; set; }


        public string Summary => Situation?.Name + ": " + SituationIncome.ToString("c");


        public double SituationIncome { get; set; }
	}
}
