using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitIOnClick : OnClick
{
    public void onClick()
    {
        Application.Quit();
    }
}
