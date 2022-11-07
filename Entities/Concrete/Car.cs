using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public string CarName { get; set; }

        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public int ModelYear { get; set; }

        public int DailyPrice { get; set; }

        public string Description { get; set; }
        public int FindeksPoint { get; set; }

    }
}
