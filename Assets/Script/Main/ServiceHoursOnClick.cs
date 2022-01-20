using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceHoursOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("ServiceHours");
    }
}
