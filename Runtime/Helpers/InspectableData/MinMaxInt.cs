// Copyright Gamelogic (c) http://www.gamelogic.co.za

using System;

namespace LiteNinja.Common
{
	/// <summary>
	/// Class for representing a bounded range.
	/// </summary>
	[Serializable]
	public class MinMaxInt
	{
		#region Public Fields

		public int min = 0;
		public int max = 1;

		#endregion

		public MinMaxInt()
		{
			min = 0;
			max = 1;
		}

		public MinMaxInt(int min, int max)
		{
			this.min = min;
			this.max = max;
		}
	}
}