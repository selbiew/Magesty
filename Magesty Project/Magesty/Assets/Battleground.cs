using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Magesty
{
    public class Battleground
    {
		int width, height;
		public Tile [,] tileArray;
		
		public Battleground(){}
		
		public Battleground(int w, int h){
			width = w;
			height = h;
			tileArray = new Tile[width,height];
			initializeBattleground();
		}
		
		void initializeBattleground(){
			int x,y;
			for (x = 0; x < width; x++){
				for (y = 0; y < height; y++){
					if (x==0 || y==0 || x==width-1 || y==height-1){
						tileArray[x,y] = new Tile();
						tileArray[x,y].initializeTile("wall",1,true);
					}
					else{
						tileArray[x,y] = new Tile();
						tileArray[x,y].initializeTile("dirt",0,false);
					}
				}
			}
		}
		
		public string printBattleground(){
			int x,y;
			string returnString = "";
			for (x = 0; x < width; x++){
				for (y = 0; y < height; y++){
					returnString += tileArray[x,y].type[0];
				}
				returnString += "\n";
			}
			return returnString;
		}
    }
}
