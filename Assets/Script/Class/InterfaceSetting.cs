﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InterfaceSetting : InterfaceObj
{
    public InterfaceSetting(Text messge, InputField inputFiled, Font font) : base(messge, inputFiled, font) { }

    TextSetting textSetting;
    InputFieldSetting inputFieldSetting;

    // 週次
    public override void dateWeekfunction(string textMessage, float pointY)
    {
        textSetting = new TextSetting(message, 0.5f, pointY, 0.3f, 0.1f);
        textSetting.function(font, FontStyle.Normal, textMessage, TextAnchor.MiddleLeft, Color.red, 7);

        inputFieldSetting = new InputFieldSetting(inputFiled, 1.15f, pointY + 0.01f, 0.9f, 0.1f);
        inputFieldSetting.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 11,
            InputField.ContentType.IntegerNumber);
    }

    // 假期
    public override void funtcionHoliday(string textMessage, float pointY)
    {
        textSetting = new TextSetting(message, 0.65f, pointY, 0.6f, 0.1f);
        textSetting.function(font, FontStyle.Normal, textMessage, TextAnchor.MiddleLeft, Color.red, 7);

        inputFieldSetting = new InputFieldSetting(inputFiled, 1.28f, pointY + 0.01f, 0.64f, 0.1f);
        inputFieldSetting.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 11,
            InputField.ContentType.IntegerNumber);
    }

    // 年與月
    public override void systemAndYear(string textMessage, float pointX)
    {
        textSetting = new TextSetting(message, pointX, 1.89f, 1f, 0.13f);
        textSetting.function(font, FontStyle.Normal, textMessage, TextAnchor.MiddleLeft, Color.red, 7);

        inputFieldSetting = new InputFieldSetting(inputFiled, pointX - 0.65f, 1.89f, 0.3f, 0.12f);
        inputFieldSetting.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 11,
            InputField.ContentType.IntegerNumber);
    }
}