﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeeklyHourcalculatioOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("WeeklyHours");
    }
}
