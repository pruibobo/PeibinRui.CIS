using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InteractionResponseModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? EmpId { get; set; }
        public string IntType { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? IntDate { get; set; }
        public string Remarks { get; set; }
    }
}
