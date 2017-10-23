using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdApp.DAL.Entities.Identity;

namespace AdApp.DAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
