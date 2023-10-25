using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class eventDropDown : MonoBehaviour
{
public List<string> list = new List<string>() {"test0 (to)", "test1 (t1)" };
public TMP_Dropdown    TMPDropdown;
public TMP_Text        text;
 
void Start () {
   
     TMPDropdown.options.Clear ();
     //foreach (string t in list)
     //{
     //    TMPDropdown.options.Add (new TMP_Dropdown.OptionData() {text=t});
     //}
}
}
