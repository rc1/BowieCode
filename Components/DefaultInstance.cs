using UnityEngine;
using System.Collections.Generic;

namespace BowieCode {

	/// <summary>
	/// Gets/sets a single static `Default` instance. Rather than have singletons, instances utilize utilitise this generic container. 
	/// </summary>
	public class DefaultInstance<T> {

		private static T _default;

		public static T Get () {
			return _default;
		}

		public static void Set ( T self ) {
			if ( _default != null && !EqualityComparer<T>.Default.Equals( _default, self ) ) {
				Debug.LogWarningFormat( "There is an existing an default instance of {0} in the scene", self.GetType().Name );
			}
			_default = self;
		}

		public static void Unset ( T self ) {
			if ( _default != null && EqualityComparer<T>.Default.Equals( _default, self ) ) {
				_default = default(T);
			}
		}

	}

}
