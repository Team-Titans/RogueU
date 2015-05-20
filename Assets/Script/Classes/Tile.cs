using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
	enum TileDef { EMPTY, WALL,FLOOR,DOOR,STAIRS,PATH};
	enum TrapDef { EMPTY, BEAR, PIT, MIST };
	class Tile : Entity
	{

		//TO ADD: Carbon, Item
		public int carbon;
		public int item;

		public int trapType;
		public bool isDark;
		public bool isTrapSet;
		public bool isTrapVisible;
		public bool hasChanged;
		public Tile()
		{
			carbon = 0;
			item = 0;

			trapType = 0;
			isDark = false;
			isTrapSet = false;
			isTrapVisible = false;
			hasChanged = false;
		}

	}
}
