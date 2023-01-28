using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class TimeConversionInterface 
{
    private Text hour, minute, calculatorProcess, calculatorResult;
    private InputField hourInput, minuteInput;
    private RectTransform hourManage, minuteMange, calculatorArea;

    AreaSetting hourMangeSetting, minuteMangeSetting, calculatorAreaSetting;

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
  
    TextSetting calculatorProcessSetting, calculatorResultSetting;

    public TimeConversionInterface(Image breakGroud, RectTransform calculatorArea, Text calculatorProcess, Text calculatorResult)
    {
        this.breakGroud = breakGroud;
        this.calculatorArea = calculatorArea;
        this.calculatorProcess = calculatorProcess;
        this.calculatorResult = calculatorResult;
    }

    private Button button1, button2, button3, button4;
    ButtonSetting button1Setting, button2Setting, button3Setting, button4Setting;

    public TimeConversionInterface(Button button1, Button button2, Button button3, Button button4)
    {
        this.button1 = button1;
        this.button2 = button2;
        this.button3 = button3;
        this.button4 = button4;
    }

    public void calculatorHorizontalBtns(float pointY, Font font, string btnStr1, string btnStr2, string btnStr3,  string btnStr4,
        UnityAction unityAction1, UnityAction unityAction2, UnityAction unityAction3, UnityAction unityAction4)
    {
        button1Setting = new ButtonSetting(button1, 0.4f, 0.7f + pointY, 0.3f, 0.15f, unityAction1);
        button1Setting.textStype(font, FontStyle.Normal, btnStr1, TextAnchor.MiddleCenter, Color.black, 7, 0);

        button2Setting = new ButtonSetting(button2, 0.8f, 0.7f + pointY, 0.3f, 0.15f, unityAction2);
        button2Setting.textStype(font, FontStyle.Normal, btnStr2, TextAnchor.MiddleCenter, Color.black, 7, 0);

        button3Setting = new ButtonSetting(button3, 1.2f, 0.7f + pointY, 0.3f, 0.15f, unityAction3);
        button3Setting.textStype(font, FontStyle.Normal, btnStr3, TextAnchor.MiddleCenter, Color.black, 7, 0);

        button4Setting = new ButtonSetting(button4, 1.6f, 0.7f + pointY, 0.3f, 0.15f, unityAction4);
        button4Setting.textStype(font, FontStyle.Normal, btnStr4, TextAnchor.MiddleCenter, Color.black, 7, 0);
    }

    // 計算機介面
    public void calculayoutSetting(Font font, float povitY, int textSize)
    {
        breakGroudSetting = new ImageSetting(breakGroud, 1f, 0.6f, 1.6f, 0.66f);
        breakGroudSetting.scrollRectImage(null, false, true, calculatorArea);

        calculatorAreaSetting = new AreaSetting(calculatorArea, Vector2.zero, new Vector2(1, 1), new Vector2(0.5f, 1f));
        calculatorAreaSetting.defaultFunction(new Vector2(1, Screen.height / 2 * povitY));

        // 顯示過程
        calculatorProcessSetting = new TextSetting(calculatorProcess, 1f, 0.86f, 1.5f, 0.1f, "", 7);
        calculatorProcessSetting.style(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black);

        // 顯示計算後結果
        calculatorResultSetting = new TextSetting(calculatorResult, 1f, 0.76f, 1.5f, 0.1f, "", 7);
        calculatorResultSetting.style(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black);

    }

    // 背景
    public void breakGroud_Layout(string instructionMessage)
    {
        breakGroudSetting = new ImageSetting(breakGroud, 1f, 1f, 1.6f, 1.6f);
        breakGroudSetting.function(null);

        instructionBreakGroudSetting = new ImageSetting(instructionBreakGroud, 1f, 1.59f, 1.6f, 0.42f);
        instructionBreakGroudSetting.scrollRectImage(null, false, true, instruction.rectTransform);

        // instructionBreakGroud 物件底下子物件
        instruction.transform.parent = instructionBreakGroud.transform;

        instructionSetting = new TextSetting(instruction, 0, 0, 0, 0.74f, instructionMessage, 7);
        instructionSetting.areaText(new Vector2(0, 0f), new Vector2(1, 1), new Vector2(0.5f, 1f));
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
        minuteSetting.dateWeekfunction("分鐘", pointY - 0.15f, Color.red);
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