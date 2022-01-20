using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeekInterface
{
    private RectTransform manage;
    private Text dateText, hourText, minuteText, cycleText, holidayText;
    private InputField hourInput, minuteInput, cycleInput, holidayInput;

    InterfaceSetting hourSetting;
    InterfaceSetting minuteSetting;
    InterfaceSetting cycleSetting;
    InterfaceSetting holidaySetting;

    AreaSetting manageSetting;
    TextSetting dateMessageSetting;

    public WeekInterface(RectTransform manage, Text dateText, Text hourText, InputField hourInput,
        Text minuteText, InputField minuteInput, Text cycleText, InputField cycleInput, Text holidayText,
        InputField holidayInput)
    {
        this.manage = manage;
        this.dateText = dateText;
        this.hourText = hourText;
        this.hourInput = hourInput;
        this.minuteText = minuteText;
        this.minuteInput = minuteInput;
        this.cycleText = cycleText;
        this.cycleInput = cycleInput;
        this.holidayText = holidayText;
        this.holidayInput = holidayInput;
    }

    public WeekInterface(RectTransform manage, Text dateText, Text hourText, InputField hourInput, Text minuteText,
        InputField minuteInput)
    {
        this.manage = manage;
        this.dateText = dateText;
        this.hourText = hourText;
        this.hourInput = hourInput;
        this.minuteText = minuteText;
        this.minuteInput = minuteInput;
    }


    private Text systemText, yearText, monthText;
    private InputField yearInput, monthInput;

    TextSetting systemSetting;

    InterfaceSetting yearSetting;
    InterfaceSetting monthSetting;

    public WeekInterface(Text systemText, Text yearText, InputField yearInput, Text monthText, InputField monthInput)
    {
        this.systemText = systemText;
        this.yearText = yearText;
        this.yearInput = yearInput;
        this.monthText = monthText;
        this.monthInput = monthInput;
    }

    private Image breakGroudArea, instructionBreakGroud, weekDayBreakGroud;
    private Text instructionMessage;
    private RectTransform weekArea;

    ImageSetting breakGroudAreaSetting, instructionBreakGroudSetting, weekDayBreakGroudSetting;
    TextSetting instructionMessageSetting;
    AreaSetting weekAreaSetting;

    public WeekInterface(Image breakGroudArea, Image instructionBreakGroud, Image weekDayBreakGroud,
        Text instructionMessage, RectTransform weekArea)
    {
        this.breakGroudArea = breakGroudArea;
        this.instructionBreakGroud = instructionBreakGroud;
        this.weekDayBreakGroud = weekDayBreakGroud;
        this.instructionMessage = instructionMessage;
        this.weekArea = weekArea;
    }

    // 背景介面
    public void breakGroud_Layout(string instruction)
    {
        breakGroudAreaSetting = new ImageSetting(breakGroudArea, 1f, 1f, 1.6f, 1.6f);
        breakGroudAreaSetting.function(null);

        // breakGroudArea 物件底下子物件
        instructionBreakGroud.transform.parent = breakGroudArea.transform;
        weekDayBreakGroud.transform.parent = breakGroudArea.transform;

        // 說明區域背景
        instructionBreakGroudSetting = new ImageSetting(instructionBreakGroud, 1, 1.6f, 1.6f, 0.41f);
        instructionBreakGroudSetting.function(null, false, true, instructionMessage.rectTransform);

        //instructionBreakGroud 物件底下子物件
        instructionMessage.transform.parent = instructionBreakGroud.transform;

        instructionMessageSetting = new TextSetting(instructionMessage, 5f, 0, 0, 0.12f);
        instructionMessageSetting.function(7, instruction, Vector2.zero, new Vector2(1, 1), new Vector2(0.5f, 1));

        // 週次區域背景
        weekDayBreakGroudSetting = new ImageSetting(weekDayBreakGroud, 1f, 0.9f, 1.6f, 0.8f);
        weekDayBreakGroudSetting.function(null, false, true, weekArea);

        // weekDayBreakGroud 物件底下子物件
        weekArea.transform.parent = weekDayBreakGroud.transform;

        weekAreaSetting = new AreaSetting(weekArea, Vector2.zero, new Vector2(1, 1), new Vector2(0.5f, 1));
        weekAreaSetting.defaultFunction(new Vector2(0, Screen.height / 2 * 4.1f));
    }

    // --------

    // 週次.年.月 介面
    public void system_Layout(Font font, float pointX, string systemMessage)
    {
        systemSetting = new TextSetting(systemText, pointX, 1.89f, 1f, 0.13f);
        systemSetting.function(font, FontStyle.Normal, systemMessage, TextAnchor.MiddleLeft, Color.green, 7);

        yearSetting = new InterfaceSetting(yearText, yearInput, font);
        yearSetting.systemAndYear("年", pointX + 0.88f);

        monthSetting = new InterfaceSetting(monthText, monthInput, font);
        monthSetting.systemAndYear("月", pointX + 1.4f);
    }

    public int getYearValue() 
    {
        return Int32.Parse(yearInput.text);
    }

    public int getMonthValue()
    {
        return Int32.Parse(monthInput.text);
    }

    // --------

    // 週期介面
    public void week_Layout(Font font, float pointY, string dateMessage)
    {
        manageSetting = new AreaSetting(manage, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f));
        manageSetting.defaultFunction(Vector2.zero);

        dateText.transform.parent = manage.transform;
        hourText.transform.parent = manage.transform;
        hourInput.transform.parent = manage.transform;
        minuteText.transform.parent = manage.transform;
        minuteInput.transform.parent = manage.transform;
        cycleText.transform.parent = manage.transform;
        cycleInput.transform.parent = manage.transform;
        holidayText.transform.parent = manage.transform;
        holidayInput.transform.parent = manage.transform;

        dateMessageSetting = new TextSetting(dateText, 0.5f, pointY, 0.3f, 0.1f);
        dateMessageSetting.function(font, FontStyle.Normal, dateMessage, TextAnchor.MiddleLeft, Color.blue, 7);

        // 小時
        hourSetting = new InterfaceSetting(hourText, hourInput, font);
        hourSetting.dateWeekfunction("小時", pointY - 0.12f);

        // 分鐘
        minuteSetting = new InterfaceSetting(minuteText, minuteInput, font);
        minuteSetting.dateWeekfunction("分鐘", pointY - 0.25f);

        // 週次
        cycleSetting = new InterfaceSetting(cycleText, cycleInput, font);
        cycleSetting.dateWeekfunction("週次", pointY - 0.38f);

        // 請假次數
        holidaySetting = new InterfaceSetting(holidayText, holidayInput, font);
        holidaySetting.funtcionHoliday("請假次數", pointY - 0.51f);
    }

    // 加班介面
    public void workOvertime_Layout(Font font, float pointY, string dateMessage)
    {
        manageSetting = new AreaSetting(manage, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f));
        manageSetting.defaultFunction(Vector2.zero);

        dateMessageSetting = new TextSetting(dateText, 0.5f, pointY, 0.3f, 0.1f);
        dateMessageSetting.function(font, FontStyle.Normal, "加班", TextAnchor.MiddleLeft, Color.blue, 7);

        // 小時
        hourSetting = new InterfaceSetting(hourText, hourInput, font);
        hourSetting.dateWeekfunction("小時", pointY - 0.12f);

        // 分鐘
        minuteSetting = new InterfaceSetting(minuteText, minuteInput, font);
        minuteSetting.dateWeekfunction("分鐘", pointY - 0.25f);
    }

    public int getHourValue()
    {
        if (hourInput.text == "")
            return 0;

        return Int32.Parse(hourInput.text);
    }

    public int getMinuteValue()
    {       
        if(minuteInput.text == "")     
            return 0;
       
        return Int32.Parse(minuteInput.text);
    }

    public void setCycleValue(int message)
    {
        cycleInput.text = message.ToString();
    }

    public int getCycleValue()
    {
        return Int32.Parse(cycleInput.text);
    }


   public int getHoliday() 
   {
        if (holidayInput.text == "")
            return 0;

        return Int32.Parse(holidayInput.text);
   }
}
