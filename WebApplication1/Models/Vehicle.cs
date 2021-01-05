using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public DateTime LastUpdate { get; set; }

        public int FeatureId { get; set; }
        public ICollection<Feature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<Feature>();
        }
    }
}
