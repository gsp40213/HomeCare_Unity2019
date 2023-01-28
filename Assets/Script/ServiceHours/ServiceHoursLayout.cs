using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ServiceHoursLayout : MonoBehaviour
{
    public Image breakGroud_image;
    public Image breakGraoud_Area_Image;

    public RectTransform area_RectTransform;
    AreaSetting area;

    // 開始服務
    public RectTransform startManage__RectTransform;
    public Text startMessage_text;
    public Text startHour_text;
    public InputField startHourInput_InputField;
    public Text startMinute_text;
    public InputField startMinuteInput_inputField;

    // 結束服務
    public RectTransform endManage__RectTransform;
    public Text endMessage_text; 
    public Text endHourMessage_Text;  
    public InputField endHourInput_InputField;  
    public Text endMinuteMessage_Text;
    public TextSetting endMinuteMessage;
    public InputField endMinuteInput_InputField;

    // 服務次數
    public RectTransform serivcesManage__RectTransform;
    public Text serivcesMessage_Text;
    public InputField serivcesInput_InputField;

    // 結果
    public Text result_Text;
    TextSetting result;

    public Button return_btn;
    ButtonSetting returnbtn;

    public Font textFont;
    public static ServiceInterface START_SERVICE, END_SERVICE, SERVICE_VALUE;

    ServiceInterface breakGroud;

    private void Start()
    {
        breakGroud = new ServiceInterface(breakGroud_image, breakGraoud_Area_Image, area_RectTransform);
        breakGroud.breakGroud_Layout();

        // area_RectTransform 物件底下子物件
        startManage__RectTransform.transform.parent = area_RectTransform.transform;
        endManage__RectTransform.transform.parent = area_RectTransform.transform;
        serivcesManage__RectTransform.parent = area_RectTransform.transform;

        // 開始服務
        START_SERVICE = new ServiceInterface(startManage__RectTransform, startMessage_text, startHour_text, 
            startHourInput_InputField, startMinute_text, startMinuteInput_inputField);
        START_SERVICE.serverTime_Layout(textFont, 1.25f, "開始服務");

        // 結束服務
        END_SERVICE = new ServiceInterface(endManage__RectTransform, endMessage_text, endHourMessage_Text,
            endHourInput_InputField, endMinuteMessage_Text, endMinuteInput_InputField);
        END_SERVICE.serverTime_Layout(textFont, 0.65f, "結束服務");

        // 服務次數
        SERVICE_VALUE = new ServiceInterface(serivcesManage__RectTransform, serivcesMessage_Text, serivcesInput_InputField);
        SERVICE_VALUE.serviceTime_Layout(textFont, 0.12f);

        result = new TextSetting(result_Text, 1f, 0.7f, 1.5f, 0.5f, "結果", 7);
        result.style(textFont, FontStyle.Normal, TextAnchor.MiddleLeft, Color.green);

        returnbtn = new ButtonSetting(return_btn, 1.5f, 0.1f, 0.6f, 0.15f, new ReturnOnClick().onClick);
        returnbtn.textStype(textFont, FontStyle.Normal, "上一頁", TextAnchor.MiddleCenter, Color.black, 7, 0);
    }

    public float sizeX, sizeY;

    private void FixedUpdate()
    {
        try
        {
            result.messageText(textFont, FontStyle.Normal, TextAnchor.MiddleLeft, Color.green, Calculate.RESULT());
        }
        catch { }
    }
}
