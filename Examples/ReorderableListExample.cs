using UnityEngine;
using System.Collections.Generic;
using BowieCode;

namespace BowieCode {

    public class ReorderableListExample : MonoBehaviour {

        [System.Serializable]
        public class MyDataClass {
            public string name = "";
            public bool toggle = true;
        }

        [HideInInspector]
        public List<MyDataClass> dataList = new List<MyDataClass> ();

        public bool showList = true;
 
    }

}
