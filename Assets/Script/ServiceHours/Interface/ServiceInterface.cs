using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ServiceInterface
{
    private RectTransform manage;
    private Text hour, minute, titleMessage;
    private InputField hourInput, minuteInput;

    AreaSetting manageSetting;
    TextSetting titleMessageSetting;

    InterfaceSetting hourSetting, minuteSetting;

    private Image breakGroudArea;

    ImageSetting breakGroudAreaSetting;

    public ServiceInterface(RectTransform manage, Text titleMessage, 
        Text hour, InputField hourInput, Text minute, InputField minuteInput)
    {
        this.manage = manage;
        this.titleMessage = titleMessage;
        this.hour = hour;
        this.hourInput = hourInput;
        this.minute = minute;
        this.minuteInput = minuteInput;
    }



    public ServiceInterface(Image breakGroudArea, RectTransform manage)
    {
        this.breakGroudArea = breakGroudArea;
        this.manage = manage;
    }

    public void breakGroud_Layout()
    {
        breakGroudAreaSetting = new ImageSetting(breakGroudArea, 1f, 1f, 1.6f, 1.6f);
        breakGroudAreaSetting.function(null);

        // breakGroudArea 物件底下子物件
        manage.transform.parent = breakGroudArea.transform;

        manageSetting = new AreaSetting(manage, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0.5f, 0.5f));
        manageSetting.defaultFunction(Vector2.zero);
    }

    public void serverTime_Layout(Font font, float pointY, string title)
    {
        manageSetting = new AreaSetting(manage, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        manageSetting.defaultFunction(Vector2.zero);

        titleMessageSetting = new TextSetting(titleMessage, 0.6f, pointY, 0.58f, 0.1f); 
        titleMessageSetting.function(font, FontStyle.Normal, title, TextAnchor.MiddleLeft, Color.green, 7);

        hourSetting = new InterfaceSetting(hour, hourInput, font);
        hourSetting.dateWeekfunction("小時", pointY - 0.16f);

        minuteSetting = new InterfaceSetting(minute, minuteInput, font);
        minuteSetting.dateWeekfunction("分鐘", pointY - 0.36f);

        // manage 物件底下子物件
        titleMessage.transform.parent = manage.transform;
        hour.transform.parent = manage.transform;
        hourInput.transform.parent = manage.transform;
        minute.transform.parent = manage.transform;
        minuteInput.transform.parent = manage.transform;
    }

    public int getMinuteValue()
    {
        if (minuteInput.text == "")
            return 0;

        return Int32.Parse(minuteInput.text);
    }

    public int getHourValue()
    {
        if (hourInput.text == "")
            return 0;

        return Int32.Parse(hourInput.text);
    }
}
