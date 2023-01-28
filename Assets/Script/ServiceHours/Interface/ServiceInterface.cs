using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ServiceInterface
{
    private RectTransform manage;    
    private Text hour, minute, titleMessage, serviceMessage;
    private InputField hourInput, minuteInput, serviceInputField;

    AreaSetting manageSetting;
    TextSetting titleMessageSetting;

    InterfaceSetting hourSetting, minuteSetting, servicesSetting;

    private Image breakGroud;
    private Image breaGroudArea;

    ImageSetting breakGroudSetting;
    ImageSetting breakGraoudAreaSetting;

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

    public ServiceInterface(Image breakGroud, Image breaGroudArea, RectTransform manage)
    {
        this.breakGroud = breakGroud;
        this.breaGroudArea = breaGroudArea;
        this.manage = manage;
    }

    public ServiceInterface(RectTransform manage, Text serviceMessage, InputField serviceInputField)
    {
        this.manage = manage;
        this.serviceMessage = serviceMessage;
        this.serviceInputField = serviceInputField;
    }

    public void breakGroud_Layout()
    {
        breakGroudSetting = new ImageSetting(breakGroud, 1f, 1f, 1.6f, 1.6f);
        breakGroudSetting.function(null);

        // breakGroudArea 物件底下子物件
        breaGroudArea.transform.parent = breakGroud.transform;

        breakGraoudAreaSetting = new ImageSetting(breaGroudArea, 1f, 1.4f, 1.6f, 0.8f);
        breakGraoudAreaSetting.scrollRectImage(null, false, true, manage);

        // breaGroudArea 物件底下子物件
        manage.transform.parent = breaGroudArea.transform;

        manageSetting = new AreaSetting(manage, Vector2.zero, new Vector2(1, 1), new Vector2(0.5f, 1));
        manageSetting.defaultFunction(new Vector2(0, Screen.height / 2 * 0.75f));
    }

    // 服務次數
    public void serviceTime_Layout(Font font, float pointY)
    {
        manageSetting = new AreaSetting(manage, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        manageSetting.defaultFunction(Vector2.zero);

        servicesSetting = new InterfaceSetting(serviceMessage, serviceInputField, font);
        servicesSetting.funtcionHoliday("服務次數", pointY, Color.green);

        serviceMessage.transform.parent = manage.transform;
        serviceInputField.transform.parent = manage.transform;
    }

    public void serverTime_Layout(Font font, float pointY, string title)
    {
        manageSetting = new AreaSetting(manage, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        manageSetting.defaultFunction(Vector2.zero);

        titleMessageSetting = new TextSetting(titleMessage, 0.6f, pointY, 0.58f, 0.1f, title, 7); 
        titleMessageSetting.style(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.green);

        hourSetting = new InterfaceSetting(hour, hourInput, font);
        hourSetting.dateWeekfunction("小時", pointY - 0.16f, Color.red);

        minuteSetting = new InterfaceSetting(minute, minuteInput, font);
        minuteSetting.dateWeekfunction("分鐘", pointY - 0.36f, Color.red);

        // manage 物件底下子物件
        titleMessage.transform.parent = manage.transform;
        hour.transform.parent = manage.transform;
        hourInput.transform.parent = manage.transform;
        minute.transform.parent = manage.transform;
        minuteInput.transform.parent = manage.transform;
        titleMessage.transform.parent = manage.transform;     
    }

    public int getServiceValue()
    {
        if (serviceInputField.text == "")
            return 1;

        return Int32.Parse(serviceInputField.text);
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
