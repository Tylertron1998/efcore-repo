using System.Collections.Generic;

namespace EfCoreRepo.Models
{
    public class WorkingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> FavouriteColours { get; set; }
    }
}