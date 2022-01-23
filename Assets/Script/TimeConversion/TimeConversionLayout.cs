using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeConversionLayout : MonoBehaviour
{
    public Image breakGroud_Image;
    ImageSetting breakGroud;

    public Image instructionBreakGroud_Image;
    ImageSetting instructionBreakGroud;

    public Text instruction_Text;
    TextSetting instruction;

    public RectTransform hourManage_RectTransfrom;
    public Text hourMessage_Text;
    public InputField hourInput_InputField;

    public RectTransform minuteManage_RectTransfrom;
    public Text minuteMessage_Text;
    public InputField minuteInput_InputField;

    public Text result_Text;
    TextSetting result;

    public Text systemMessage_Text;
    TextSetting systemMessage;

    public Button return_btn;
    ButtonSetting returnbtn;

    public Font textFont;

    public static TimeConversionInterface HOUR_MINUTE;
    TimeConversionInterface breakGroudInterface;

    private void Start()
    {
        breakGroudInterface = new TimeConversionInterface(breakGroud_Image, instructionBreakGroud_Image, instruction_Text);
        breakGroudInterface.breakGroud_Layout(instructionMessage());

        // breakGroud_Image 物件底下子物件
        instructionBreakGroud_Image.transform.parent = breakGroud_Image.transform;
        hourManage_RectTransfrom.transform.parent = breakGroud_Image.transform;
        minuteManage_RectTransfrom.transform.parent = breakGroud_Image.transform;
        result_Text.transform.parent = breakGroud_Image.transform;

        // 小時與分鐘
        HOUR_MINUTE = new TimeConversionInterface(hourManage_RectTransfrom, hourMessage_Text, hourInput_InputField,
            minuteManage_RectTransfrom, minuteMessage_Text, minuteInput_InputField);
        HOUR_MINUTE.hourAndminute(textFont, 1.27f);


        result = new TextSetting(result_Text, 1f, 0.6f, 1.42f, 0.1f);
        result.function(textFont, FontStyle.Normal, "結果", TextAnchor.MiddleLeft, Color.green, 7);

        systemMessage = new TextSetting(systemMessage_Text, 0.78f, 1.87f, 1.2f, 0.13f);
        systemMessage.function(textFont, FontStyle.Normal, "時間換算", TextAnchor.MiddleLeft, Color.red, 7);

        returnbtn = new ButtonSetting(return_btn, 1.5f, 0.1f, 0.6f, 0.15f, new ReturnOnClick().onClick);
        returnbtn.function(textFont, FontStyle.Normal, "上一頁", TextAnchor.MiddleCenter, Color.black, 7);
    }

    private void FixedUpdate()
    {
        try
        {
            result.function(textFont, FontStyle.Normal, TimeConversionCalculation.RESULT(), TextAnchor.MiddleLeft, Color.green, 7);
        }
        catch { }
    }

    string instructionMessage()
    {
        string str = "說明: \n輸入總時數計算。\n例如: 服務時間:32小時\n172分鐘換算為34小時\n52分鐘";


        return str;
    }
}
