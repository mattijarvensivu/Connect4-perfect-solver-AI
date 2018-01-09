using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Rows {
    [System.Serializable]
    public struct rowdata
    {
        public Image spot;
    }
    public rowdata[] rows = new rowdata[7];
    
}
