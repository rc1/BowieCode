using System.Collections.Generic;

namespace BowieCode  {
	
	public class Cycle<T> {

		public List<T> enumerable {
			get { return _enumerable; }
		}

		private List<T> _enumerable;
		private int _idx = -1;

		public Cycle ( List<T> enumerable ) {
			_enumerable = enumerable;
		}

		public T Next () {
			if (++_idx >= enumerable.Count) {
				_idx = 0;
			}
			return _enumerable[_idx];
		}

		public T Previous () {
			if ( --_idx < 0 ) {
				_idx = _enumerable.Count - 1;
			}
			return _enumerable[_idx];
		}
	}

}
