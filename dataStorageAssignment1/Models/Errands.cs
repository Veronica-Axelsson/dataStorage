using dataStorage.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStorage.Models
{
    internal class Errands
    {
        public string CustomerPhoneNr { get; set; } = null!;
        public Guid Id { get; set; }
        public string CustomerDescription { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime ErrandTimeCreated { get; set; }
        public DateTime TimeEmployeeComment { get; set; }
        public string EmployeeComment { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        

    }
}
