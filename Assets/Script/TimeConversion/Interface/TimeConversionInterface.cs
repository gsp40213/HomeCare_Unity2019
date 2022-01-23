using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeConversionInterface 
{
    private Text hour, minute;
    private InputField hourInput, minuteInput;
    private RectTransform hourManage, minuteMange;

    AreaSetting hourMangeSetting, minuteMangeSetting;

    InterfaceSetting hourSetting, minuteSetting;

    public TimeConversionInterface(RectTransform hourManage, Text hour, InputField hourInput,
        RectTransform minuteMange, Text minute, InputField minuteInput)
    {
        this.hourManage = hourManage;
        this.hour = hour;        
        this.hourInput = hourInput;

        this.minuteMange = minuteMange;
        this.minute = minute;
        this.minuteInput = minuteInput;
    }

    private Image breakGroud, instructionBreakGroud;
    private Text instruction;

    ImageSetting breakGroudSetting, instructionBreakGroudSetting;
    TextSetting instructionSetting;

    public TimeConversionInterface(Image breakGroud, Image instructionBreakGroud, Text instruction)
    {
        this.breakGroud = breakGroud;
        this.instructionBreakGroud = instructionBreakGroud;
        this.instruction = instruction;
    }

    // 背景
    public void breakGroud_Layout(string instructionMessage)
    {
        breakGroudSetting = new ImageSetting(breakGroud, 1f, 1f, 1.6f, 1.6f);
        breakGroudSetting.function(null);

        instructionBreakGroudSetting = new ImageSetting(instructionBreakGroud, 1f, 1.59f, 1.6f, 0.42f);
        instructionBreakGroudSetting.function(null, false, true, instruction.rectTransform);

        // instructionBreakGroud 物件底下子物件
        instruction.transform.parent = instructionBreakGroud.transform;

        instructionSetting = new TextSetting(instruction, 0, 0, 0, 0.1f);
        instructionSetting.function(7, instructionMessage, new Vector2(0, 0f), new Vector2(1, 1), new Vector2(0.5f, 1f));
    }

    //　小時與分鐘
    public void hourAndminute(Font font, float pointY)
    {
        hourMangeSetting = new AreaSetting(hourManage, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f));
        hourMangeSetting.defaultFunction(Vector2.zero);

        // hourManage 物件底下子物件
        hour.transform.parent = hourManage.transform;
        hourInput.transform.parent = hourManage.transform;

        hourSetting = new InterfaceSetting(hour, hourInput, font);
        hourSetting.dateWeekfunction("小時", pointY, Color.red);

        minuteMangeSetting = new AreaSetting(minuteMange, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f));
        minuteMangeSetting.defaultFunction(Vector2.zero);

        // minuteMange 物件底下子物件
        minuteMange.transform.parent = minuteMange.transform;
        minuteInput.transform.parent = minuteMange.transform;

        minuteSetting = new InterfaceSetting(minute, minuteInput, font);
        minuteSetting.dateWeekfunction("分鐘", pointY - 0.27f, Color.red);
    }

    public int getHourValue()
    {
        if (hourInput.text == "")
            return 0;

        return Int32.Parse(hourInput.text);
    }

    public int getMinuteValue()
    {
        if (minuteInput.text == "")
            return 0;

        return Int32.Parse(minuteInput.text);
    }
}
