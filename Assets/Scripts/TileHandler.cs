using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
	class TileHandler
	{
		List<Tile> Tiles;

		List<Tile> GetChanged()
		{
			List<Tile> tempList = new List<Tile>();

			for (int i = 0; i < Tiles.Count(); i++)
			{
				if (Tiles[i].HasChanged)
				{
					Tiles[i].HasChanged = false;
					tempList.Add(Tiles[i]);
				}
			}

				return tempList;
		}

		//check all tiles if haschanged is true
		//if true add x, y, id to list of entity to return;
	}
}
