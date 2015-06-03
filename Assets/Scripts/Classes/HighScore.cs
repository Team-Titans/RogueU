using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Classes
{
	public class HighScore : IComparable<HighScore>
	{
		public int Score;
		public string Name;
		public HighScore(int tScore, string tName)
		{
			Score = tScore;
			Name = tName;
		}

		//public int SortByScoreAscending(int score1, int score2)
		//{
		//	return score1.CompareTo(score2);
		//}

		public int CompareTo(HighScore compareScore)
		{
			if (compareScore == null)
				return 1;
			else
				return this.Score.CompareTo(compareScore.Score);
		}

	}
}
