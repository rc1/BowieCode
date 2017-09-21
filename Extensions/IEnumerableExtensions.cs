using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BowieCode {
    
    public static class IEnumerableExtensions {

        public static Random random = new Random();

        public static T RandomElement<T>(this IEnumerable<T> enumerable) {
            return enumerable.ElementAt(Random.Range(0, enumerable.Count()));
        }
    
    }

}

