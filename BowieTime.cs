using System;

namespace BowieCode {

    /// <summary>
    /// Simple time and helpers
    /// </summary>
    public class BowieTime {
        ///<summary>
        ///An imitation of JavaScript's Date.Now function. 
        ///</summary>
        public static long Now () {
            return (long)System.Math.Floor( DateTime.UtcNow.Subtract( new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc ) ).TotalMilliseconds );
        }

        ///<summary>
        ///Returns Now as a string. As unity uses floats as doubles, a string can be useful
        ///for sending over OSC for example.
        ///</summary>
        public static string NowStr () {
            var time = Now();
            return string.Format( "{0:0}", time );
        }

        ///<summary>
        ///Returns the time of day where 0.5f is noon.
        ///</summary>
        public static float TimeOfDay () {
            // Debug.Log( "To do from hopsital project" );
            return -1000.0f;
        }

        ///<summary>
        ///Returns the time of year where 0.0f is right after the new year bells and people kiss. 0.999999f is when people drunkenly gather. 
        ///</summary>
        public static float TimeOfYear () {
            // Debug.Log( "To do from hopsital project" );
            return -1000.0f;

        }

    }

}