using UnityEngine;
using System.Collections.Generic;
using System;

namespace BowieCode {

	/// <summary>
	/// Gets/sets a single static `Default` instance. Rather than have singletons, instances
	///  utilize utilitise this generic container.
	/// </summary>
	public class DefaultInstance<T> {

		private static bool _isSet = false;

		private static T _defaultInstance = default(T);

		private static List<Action<T>> _whenSets = new List<Action<T>> ();

		/// <summary>
		/// Gets the default instance. Throws if the default instance has not been set.
		/// You can wait for the default instance to be set with `WhenSet`.
		/// </summary>
		/// <returns>The instance or default</returns>
		public static T Get () {
			if ( !_isSet ) {
				throw new Exception( "Default instance not set" );
			}
			return _defaultInstance;
		}

		/// <summary>
		/// Sets the default instance. Throws if the instance has already been set.
		/// </summary>
		/// <param name="self">default instance.</param>
		public static void Set ( T self ) {
			if ( _isSet ) {
				throw new Exception( "Default instance already set" );
			}
			_defaultInstance = self;
			_isSet = true;
			// Create a copy of the onSet actions, and trigger them
			// the copy is to prevent anything being added to the list
			var whenSets = _whenSets.ToArray();
			foreach ( var whenSet in whenSets )  {
				whenSet( _defaultInstance );
			}
			_whenSets.Clear();
		}

		/// <summary>
		/// Unsets the specified self.
		/// </summary>
		/// <returns>The unset.</returns>
		/// <param name="self">Self.</param>
		public static void Unset ( T self ) {
			if ( !_isSet ) {
				throw new Exception( "Default instance not set" );
			}
			_defaultInstance = default(T);
			_isSet = false;
		}

		/// <summary>
		/// Gets the if the default instance is set.
		/// </summary>
		/// <returns><c>true</c>, if is set was set, <c>false</c> otherwise.</returns>
		public static bool IsSet () {
			return _isSet;
		}

		/// <summary>
		/// Trigger the action immediately if the default instance has been set.
		/// Or, triggers it once it is.
		/// </summary>
		/// <param name="action">The action to be called.</param>
		public static void WhenSet ( Action<T> action ) {
			if ( _isSet ) {
				action( _defaultInstance );
			} else {
				_whenSets.Add( action );
			}
		}

	}

}
