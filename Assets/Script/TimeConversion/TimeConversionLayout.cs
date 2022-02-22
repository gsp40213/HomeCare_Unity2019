using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeConversionLayout : MonoBehaviour
{
    public Image breakGroud_Image;
    public Image instructionBreakGroud_Image;
    public Text instruction_Text;

    public RectTransform hourManage_RectTransfrom;
    public Text hourMessage_Text;
    public InputField hourInput_InputField;

    public RectTransform minuteManage_RectTransfrom;
    public Text minuteMessage_Text;
    public InputField minuteInput_InputField;

    public Text result_Text;
    TextSetting result;

    public Text calculator_Text;
    TextSetting calculatorSetting;

    // 計算機
    public Image calculatorBreakGroud_Image;
    public RectTransform calculatorArea_RectTransform;
    public Text canculatorProces, canculatorResult;
    private TextSetting canculatorProcesSetting, canculatorResultSetting;
    public Button one_Button, two_Button, three_Button, add_Button;
    public Button four_Button, five_Button, six_Button, reduce_Button;
    public Button seven_Button, eight_Butotn, nine_Button, take_Button;
    public Button zero_Button, drop_Button, equal_Buttin, remove_Button;

    public Text systemMessage_Text;
    TextSetting systemMessage;

    public Button return_btn;
    ButtonSetting returnbtn;

    public Font textFont;

    public static TimeConversionInterface HOUR_MINUTE;
    TimeConversionInterface breakGroudInterface, calculatoLayoutSetting, calculatoLayoutButtonHo1, calculatoLayoutButtonHo2,
        calculatoLayoutButtonHo3, calculatoLayoutButtonHo4;

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


        result = new TextSetting(result_Text, 1.1f, 1f, 1.42f, 0.1f);
        result.function(textFont, FontStyle.Normal, "結果", TextAnchor.MiddleLeft, Color.green, 7);

        // 計算機
        calculatorSetting = new TextSetting(calculator_Text, 0.9f, 0.76f, 1.2f, 0.1f);
        calculatorSetting.function(textFont, FontStyle.Normal, "計算機", TextAnchor.MiddleLeft, Color.red, 7);
        calculatoLayoutSetting = new TimeConversionInterface(calculatorBreakGroud_Image, calculatorArea_RectTransform, canculatorProces,
            canculatorResult);
        // 計算滑輪高度調整
        calculatoLayoutSetting.calculayoutSetting(textFont, 0.39f, 11);

        // 顯示介面
        canculatorProcesSetting = new TextSetting(canculatorProces, 0.98f, 0.7f, 1.5f, 0.2f);
        canculatorResultSetting = new TextSetting(canculatorResult, 1f, 0.76f, 1.5f, 0.1f);

         // 計算機按鈕
         calculatoLayoutButtonHo1 = new TimeConversionInterface(one_Button, two_Button, three_Button, add_Button);
        calculatoLayoutButtonHo1.calculatorHorizontalBtns(-0.1f, textFont, "1", "2", "3", "+", 
            new OnClickView().oneClick, new OnClickView().twoClick, new OnClickView().threeClick, new OnClickView().addClick);
        calculatoLayoutButtonHo2 = new TimeConversionInterface(four_Button, five_Button, six_Button, reduce_Button);
        calculatoLayoutButtonHo2.calculatorHorizontalBtns(-0.3f, textFont, "4", "5", "6", "-", 
            new OnClickView().fourClick, new OnClickView().fiveClick, new OnClickView().sixClick, new OnClickView().reduceClick);
        calculatoLayoutButtonHo3 = new TimeConversionInterface(seven_Button, eight_Butotn, nine_Button, take_Button);
        calculatoLayoutButtonHo3.calculatorHorizontalBtns(-0.5f, textFont, "7", "8", "9", "×",
            new OnClickView().sevenClick, new OnClickView().eightClick, new OnClickView().nineClick, new OnClickView().takeClick);
        calculatoLayoutButtonHo4 = new TimeConversionInterface(zero_Button, drop_Button, equal_Buttin, remove_Button);
        calculatoLayoutButtonHo4.calculatorHorizontalBtns(-0.7f, textFont, "0", "C", "=", "÷", 
            new OnClickView().zeroClick, new OnClickView().chearClick, new OnClickView().equalClick, new OnClickView().removeClick);

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
            canculatorProcesSetting.setMessage(OnClickView.RESULT_PROCESS());

            canculatorResultSetting.setMessage(OnClickView.RESULT_());
        }
        catch { }
    }

    string instructionMessage()
    {
        string str = "說明: \n輸入總時數計算。\n例如: 服務時間:32小時\n172分鐘換算為34小時\n52分鐘" 
            + "\n--------------" +
            "\n計算機目前測試階段" + "\n請勿輸入不不同算式，否\n則會出現計算問題" +
            "\n正確輸入: 1+2+3+....5=\n21，計算完請按C按鈕刪\n除，再重新輸入";


        return str;
    }
}