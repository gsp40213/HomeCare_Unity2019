using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("Main");
    }
}
