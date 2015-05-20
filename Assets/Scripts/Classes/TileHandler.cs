using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
	class TileHandler
	{
		List<Tile> Tiles;

		public TileHandler()
		{
			Tiles = new List<Tile>();

			//HARD CODING 1600 TILES
			for (int i = 0; i < 1600; i++)
			{
				Tiles.Add(new Tile());
			}
		}
		public void TileSet()
		{
			//Set the tiles here
		}

		List<Tile> GetChanged()
		{
			List<Tile> tempList = new List<Tile>();

			for (int i = 0; i < Tiles.Count(); i++)
			{
				if (Tiles[i].hasChanged)
				{
					Tiles[i].hasChanged = false;
					tempList.Add(Tiles[i]);
				}
			}

				return tempList;
		}

		//check all tiles if haschanged is true
		//if true add x, y, id to list of entity to return
	}
}
