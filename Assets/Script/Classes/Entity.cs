using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
	class Entity
	{
		public int X;
		public int Y;
		public int ID;
		public bool IsVisible;
		
		public Entity()
		{
			X = 0;
			Y = 0;
			ID = 0;
			IsVisible = false;
		}
	}
}
