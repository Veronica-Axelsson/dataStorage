using System.ComponentModel.DataAnnotations;

namespace dataStorage.Models.Entities
{
    internal class ErrandEntity 
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime ErrandTimeCreated { get; set; }
        public string CustomerDescription { get; set; } = null!;


        public Guid CommentId { get; set; }
        public CommentEntity EmployeeComment { get; set; } = null!;


        public Guid CustomersId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;


        public Guid ErrandsStatusId { get; set; }
        public ErrandStatusEntity ErrandStatus { get; set; } = null!;


        //public Guid CustomerPhoneNrId { get; set; }
        //public PhoneEntity CustomerPhoneNr { get; set; } = null!;


    }
}
