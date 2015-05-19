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
		public int TrapType;
		public bool IsDark;
		public bool IsTrapSet;
		public bool IsTrapVisible;
		public bool HasChanged;

	}
}
