using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dataStorage.Models.Entities
{
    internal class ErrandStatusEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; } = null!;


        public ICollection<ErrandEntity> Errands = new HashSet<ErrandEntity>();
    }
}
