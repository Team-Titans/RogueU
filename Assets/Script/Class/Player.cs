using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Classes
{
	//Inherits from  Carbon
	public class Player : Carbon
	{
		public int XP;
		public int Rank;
		public int Gold;
		public int Hunger;

		//NOTE: Possible class
		public List<int> Inventory;

		public void Use(/*Item a_Item*/)
		{

		}
	}
}
