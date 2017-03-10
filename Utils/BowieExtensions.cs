using System.Collections.Generic;
using System;

namespace BowieCode {

	public static class BowieExtensions {

		public static void ForEachWithIndex<T> ( this IEnumerable<T> ie, Action<T, int> action ) {
			var i = 0;
			foreach ( var e in ie ) action( e, i++ );
		}

	}
}