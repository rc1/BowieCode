namespace BowieCode {

    public partial class BowieMath {

        /// <summary>
        /// Change an input from one range to another.
        /// </summary>
        /// <param name="input">The value to change</param>
        /// <param name="inputMin">The value's min in range</param>
        /// <param name="inputMax">The value's max in range</param>
        /// <param name="outputMin">The output's min in range</param>
        /// <param name="outputMax">The output's max in range</param>
        /// <param name="clamp">Constraigns the output to the max range</param>
        /// <returns></returns>
        static public float MapIntervalF ( float input, float inputMin, float inputMax, float outputMin, float outputMax, bool clamp = false ) {
            input = ( input - inputMin ) / ( inputMax - inputMin );
            float output = input * ( outputMax - outputMin ) + outputMin;
            if ( clamp ) {
                if ( outputMax < outputMin ) {
                    if ( output < outputMax ) {
                        output = outputMax;
                    }
                    else if ( output > outputMin ) {
                        output = outputMin;
                    }
                }
                else {
                    if ( output > outputMax ) {
                        output = outputMax;
                    }
                    else if ( output < outputMin ) {
                        output = outputMin;
                    }
                }
            }
            return output;
        }
    }
}
