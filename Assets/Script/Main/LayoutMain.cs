using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutMain : MonoBehaviour
{
    public Text systemMessage_text;
    TextSetting systemMessage;

    public Image buttonArea_Image;
    public RectTransform area_RectTransform;

    public Button quit_btn;
    ButtonSetting quit;
   
    public Button serviceHours_btn;
    ButtonSetting serviceHours;

    public Button timeConversion_btn;
    ButtonSetting timeConversion;

    public Button weeklyHourcalculation_btn;
    ButtonSetting weeklyHourcalculatio;

    public Button kilometerCalculation_brn;
    ButtonSetting kilometerCalculation;

    public Button salaryCalculation_btn;
    ButtonSetting salaryCalculation;

    MainInterface buttonAreaSetting;

    public Font textFont;
    private void Start()
    {
        systemMessage = new TextSetting(systemMessage_text, 1f, 1.8f, 1.5f, 0.3f);
        systemMessage.function(textFont, FontStyle.Normal, "居家服務小工具", TextAnchor.UpperLeft, Color.red, 5);  

        quit = new ButtonSetting(quit_btn, 1.4f, 0.1f, 0.8f, 0.15f, new QuitIOnClick().onClick);
        quit.function(textFont, FontStyle.Normal, "離開", TextAnchor.MiddleCenter, Color.black, 7);

        // 按鈕區域
        buttonAreaSetting = new MainInterface(buttonArea_Image, area_RectTransform);
        buttonAreaSetting.buttonArea_Layout();

        // area_RectTransform 物件底下子物件
        serviceHours_btn.transform.parent = area_RectTransform.transform;
        timeConversion_btn.transform.parent = area_RectTransform.transform;
        weeklyHourcalculation_btn.transform.parent = area_RectTransform.transform;
        kilometerCalculation_brn.transform.parent = area_RectTransform.transform;
        salaryCalculation_btn.transform.parent = area_RectTransform.transform;


        serviceHours = new ButtonSetting(serviceHours_btn, 1f, 1.58f, 1.1f, 0.15f, new ServiceHoursOnClick().onClick);
        serviceHours.function(textFont, FontStyle.Normal, "服務時間計算", TextAnchor.MiddleCenter, Color.black, 5);

        timeConversion = new ButtonSetting(timeConversion_btn, 1f, 1.3f, 1.1f, 0.15f, new TimeConversionOnClick().onClick);
        timeConversion.function(textFont, FontStyle.Normal, "時間換算", TextAnchor.MiddleCenter, Color.black, 5);

        weeklyHourcalculatio = new ButtonSetting(weeklyHourcalculation_btn, 1f, 1.02f, 1.1f, 0.15f, new WeeklyHourcalculatioOnClick().onClick);
        weeklyHourcalculatio.function(textFont, FontStyle.Normal, "週次時數", TextAnchor.MiddleCenter, Color.black, 5);

        kilometerCalculation = new ButtonSetting(kilometerCalculation_brn, 1f, 0.74f, 1.1f, 0.15f, new KilometerCalculationOnClick().onClick);
        kilometerCalculation.function(textFont, FontStyle.Normal, "公里數估算", TextAnchor.MiddleCenter, Color.black, 5);
        kilometerCalculation.setInteracTable(false);

        salaryCalculation = new ButtonSetting(salaryCalculation_btn, 1f, 0.46f, 1.1f, 0.15f, new SalaryCalculationOnClick().onClick);
        salaryCalculation.function(textFont, FontStyle.Normal, "薪資估算", TextAnchor.MiddleCenter, Color.black, 5);
        salaryCalculation.setInteracTable(false);
    }
}