using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public void OnButtonClick()
    {
        print("OnButtonClick");
    }


    public void OnButtonClick(int i)
    {
        print("OnButtonClick" + i);
    }
}
