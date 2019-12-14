using TestApp.Common.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models
{


    [Table("Person.Person")]
    public partial class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataNames("BusinessEntityID", "BusinessEntityID")]
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(2)]
        [DataNames("PersonType", "PersonType")]
        public string PersonType { get; set; }

        [DataNames("NameStyle", "NameStyle")]
        public bool NameStyle { get; set; }

        [StringLength(8)]
        [DataNames("Title", "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        [DataNames("FirstName", "FirstName")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [DataNames("MiddleName", "MiddleName")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [DataNames("LastName", "LastName")]
        public string LastName { get; set; }

        [StringLength(10)]
        [DataNames("Suffix", "Suffix")]
        public string Suffix { get; set; }

        [DataNames("EmailPromotion", "EmailPromotion")]
        public int EmailPromotion { get; set; }

        [DataNames("ModifiedDate", "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
