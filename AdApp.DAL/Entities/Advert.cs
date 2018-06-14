using AdApp.DAL.Entities.Identity;

namespace AdApp.DAL.Entities
{
    public class Advert : Identity.Identity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }


}