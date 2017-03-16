using System.Collections.Generic;
using System;
using UnityEngine;

namespace BowieCode {

	public static class BowieExtensions {

		/// <summary>
		/// Collection iterator with the value and index
		/// </summary>
		public static void ForEachWithIndex<T> ( this IEnumerable<T> ie, Action<T, int> action ) {
			var i = 0;
			foreach ( var e in ie ) action( e, i++ );
		}

		/// <summary>
		/// Gets the last key time.
		/// </summary>
		/// <returns>The last key's time.</returns>
		/// <param name="curve">Curve.</param>
		public static float GetLastKeyTime ( this AnimationCurve curve ) {
			if ( curve.length == 0 ) {
				return 0.0f;
			}
			return curve[ curve.length - 1 ].time;
		}

	}
}