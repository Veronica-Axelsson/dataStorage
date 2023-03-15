using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStorage.Models.Entities
{
    internal class CommentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime TimeEmployeeComment { get; set; }
        public string EmployeeComment { get; set; } = null!;


        public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
