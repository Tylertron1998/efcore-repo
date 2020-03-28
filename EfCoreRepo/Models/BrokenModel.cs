using System.Collections.Generic;

namespace EfCoreRepo.Models
{
    public class BrokenModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Colours> FavouriteColours { get; set; }
    }
}