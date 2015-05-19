using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
	//Inherits from  Carbon
	class Player : Carbon
	{
		public int XP;
		public int Rank;
		public int Gold;

		//NOTE: Possible class
		public List<int> Inventory;

		public void Equip(Item a_Item);
		public void Use(Item a_Item);
		//Pickup from MoveTo of Carbon
	}

}
