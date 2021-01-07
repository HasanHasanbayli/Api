using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}