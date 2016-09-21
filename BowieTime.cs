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
			return (long) System.Math.Floor( DateTime.UtcNow.Subtract( new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc ) ).TotalMilliseconds );
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
		///Returns the time of day where 0.5f is noon for now.
		///</summary>
		public static float PercentOfDay () {
			return PercentOfDay( DateTime.Now );
		}

		///<summary>
		///Returns the time of day where 0.5f is noon.
		///</summary>
		public static float PercentOfDay ( DateTime dateTime ) {
			DateTime currentDay = new DateTime( dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0 );
			DateTime nextDay = new DateTime( dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59 );
			TimeSpan aDay = nextDay - currentDay;
			TimeSpan soFar = dateTime - currentDay;
			return (float) ( soFar.TotalMilliseconds / aDay.TotalMilliseconds );
		}

		///<summary>
		///Returns the time of day where 0.5f is noon.
		///</summary>
		public static float PercentOfDay ( float hours, float mins ) {
			float value = hours * ( 1.0f / 24.0f );
			value += mins * ( 1.0f / 24.0f / 60.0f );
			return value;
		}

		///<summary>
		///Returns the percent of year for now where 0.0f is right after the new year bells and people kiss. 0.999999f is when people drunkenly gather. 
		///</summary>
		public static float PercentOfYear () {
			return PercentOfYear( DateTime.Now );
		}

		///<summary>
		///Returns the percent of year where 0.0f is right after the new year bells and people kiss. 0.999999f is when people drunkenly gather. 
		///</summary>
		public static float PercentOfYear ( DateTime dateTime ) {
			DateTime currentYear = new DateTime ( dateTime.Year, 1, 1, 0, 0, 0 );
			DateTime nextYear = new DateTime ( dateTime.Year + 1, 1, 1, 0, 0, 0 );
			TimeSpan aYear = nextYear - currentYear;
			TimeSpan soFar = dateTime - currentYear;
			return (float)(soFar.TotalMinutes / aYear.TotalMinutes);
		}

	}

}