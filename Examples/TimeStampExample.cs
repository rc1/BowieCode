using UnityEngine;
using UnityEngine.UI;
using BowieCode;

namespace BowieCode {

    public class TimeStampExample : MonoBehaviour {

        private Text _text;
    
	    void Start () {
	        _text = GetComponent<Text> ();
	    }
	
	    void Update () {
			_text.text = string.Format( "{0}\n{1:0.000} of today, {2:0.000} of year", BowieTime.NowStr(), BowieTime.PercentOfDay(), BowieTime.PercentOfYear() );
	    }
    }

}
