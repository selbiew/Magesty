using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class Tile
    {
        public string type { get; set; }
        public int typeID { get; set; }
        public bool hasEntity { get; set; }
        public Entity entity { get; set; }
        public Projectile projectile { get; set; }
    }
}
