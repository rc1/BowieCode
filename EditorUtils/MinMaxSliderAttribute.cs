using UnityEngine;

namespace BowieCode {

    /// <summary>
    /// Allows a min max slider to be used as a range.
    /// </summary>
    public class MinMaxSliderAttribute : PropertyAttribute {

        public readonly float max;
        public readonly float min;
        public readonly bool showFloatFields;

        public MinMaxSliderAttribute ( float min, float max, bool showFloatFields = true ) {
            this.min = min;
            this.max = max;
            this.showFloatFields = showFloatFields;
        }

    }

}