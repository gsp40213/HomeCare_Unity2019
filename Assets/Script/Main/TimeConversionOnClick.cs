using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeConversionOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("TimeConversion");
    }
}
