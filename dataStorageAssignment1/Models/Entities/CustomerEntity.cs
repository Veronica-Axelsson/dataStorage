using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dataStorage.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]

    internal class CustomerEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        //[StringLength(20)]
        //public string CustomerPhoneNr { get; set; } = null!;


        //public Guid CustomerPhoneNrId2 { get; set; }
        //public PhoneEntity CustomerPhoneNr { get; set; } = null!;


        public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
