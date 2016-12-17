using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Magesty
{
    public class Tile
    {
        public string type { get; set; }
		public bool isWall { get; set; }
        public int typeID { get; set; }
        public bool hasEntity { get; set; }
        public Entity entity { get; set; }
        //public Projectile projectile { get; set; }
		
		public Tile(){
			type = "";
			isWall = false;
			typeID = 0;
			hasEntity = false;
			entity = null;
		}
		
		public void initializeTile(string newType, int newID, bool newWall){
			if (newType != null) type = newType;
			if (newWall != null) isWall = newWall;
			if (newID != null) typeID = newID;
		}
		
		public void addEntity(Entity newEntity){
			hasEntity = true;
			entity = newEntity;
		}
    }
}
