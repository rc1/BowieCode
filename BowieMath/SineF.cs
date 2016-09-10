﻿using UnityEngine;

namespace BowieCode {

    public partial class BowieMath {

        /// <summary>
        /// Helper to make a sine wave with an amplitude and frequency
        /// </summary>
        /// <param name="time">Use Time.time</param>
        /// <param name="amplitude">The range of the output</param>
        /// <param name="cyclesPerSecond">The number of cycles per second</param>
        /// <returns></returns>
        static public float SineF ( float time, float amplitude, float cyclesPerSecond ) {
            return amplitude * Mathf.Sin( 2.0f * Mathf.PI * cyclesPerSecond * time );
        }

    }

}