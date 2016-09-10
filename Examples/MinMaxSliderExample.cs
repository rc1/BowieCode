using UnityEngine;
using BowieCode;

namespace BowieCode {

    public class MinMaxSliderExample : MonoBehaviour {

        [MinMaxSlider( 0.0f, 1.0f )]
	    public Vector2 range;

        [MinMaxSlider( 0.0f, 1.0f, false )]
        public Vector2 rangleOnly;

    }

}
