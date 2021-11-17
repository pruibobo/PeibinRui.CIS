using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class InteractionWithCliEmpModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? EmpId { get; set; }
        public string IntType { get; set; }
        public DateTime? IntDate { get; set; }
        public string Remarks { get; set; }
        public List<Client> Clients { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
