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
			Carbon = 0;
			Item = 0;

			TrapType = 0;
			IsDark = false;
			IsTrapSet = false;
			IsTrapVisible = false;
			HasChanged = false;
		}

	}
}
