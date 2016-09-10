using UnityEngine;

namespace BowieCode {

    // http://devmag.org.za/2012/07/12/50-tips-for-working-with-unity-best-practices/

    /// <summary>
    /// A generic singleton class. Inherit from this to make any class a singleton
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        protected static T instance;

        /// <summary>
        /// Returns an instance of the singleton
        /// </summary>
        public static T Instance {
            get {
                if ( instance == null ) {
                    instance = (T)FindObjectOfType( typeof( T ) );

                    if ( instance == null ) {
                        Debug.LogError( "An instance of " + typeof( T ) +
                           " is needed in the scene, but there is none." );
                    }
                }

                return instance;
            }
        }
    }

}
