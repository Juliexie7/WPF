using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public class Passport
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string PassportNo { get; set; }

        [Required]
        [StringLength(10)]
        public string ExpirDate { get; set; }

        [Required]
        public bool IsValid { get; set; }

        public Passport() { }

        public Passport(string firstName, string lastName, string passportNo, string expirdate, bool isValid) 
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNo = passportNo;
            ExpirDate = expirdate;
            IsValid = isValid;
        }
    }
}
