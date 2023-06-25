using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Category
    {
        public Category()
        {
            Leads = new Collection<Lead>();
        }
        public int Id { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "The Name field is mandatory!")]
        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<Lead>? Leads { get; set; }
    }
}
