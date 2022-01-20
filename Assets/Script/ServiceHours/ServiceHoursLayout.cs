using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ServiceHoursLayout : MonoBehaviour
{
    public Image breakGroudArea_image;
    ImageSetting breakGroudArea;

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


    // 結果
    public Text result_Text;
    TextSetting result;

    public Button return_btn;
    ButtonSetting returnbtn;

    public Font textFont;
    public static ServiceInterface START_SERVICE, END_SERVICE;

    ServiceInterface breakGroud;

    private void Start()
    {
        breakGroud = new ServiceInterface(breakGroudArea_image, area_RectTransform);
        breakGroud.breakGroud_Layout();

        // area_RectTransform 物件底下子物件
        startManage__RectTransform.transform.parent = area_RectTransform.transform;
        endManage__RectTransform.transform.parent = area_RectTransform.transform;

        // 開始服務
        START_SERVICE = new ServiceInterface(startManage__RectTransform, startMessage_text, startHour_text, 
            startHourInput_InputField, startMinute_text, startMinuteInput_inputField);
        START_SERVICE.serverTime_Layout(textFont, 1.6f, "開始服務");

        // 結束服務
        END_SERVICE = new ServiceInterface(endManage__RectTransform, endMessage_text, endHourMessage_Text,
            endHourInput_InputField, endMinuteMessage_Text, endMinuteInput_InputField);
        END_SERVICE.serverTime_Layout(textFont, 1, "結束服務");

        result = new TextSetting(result_Text, 1f, 0.46f, 1.42f, 0.1f);
        result.function(textFont, FontStyle.Normal, "結果", TextAnchor.MiddleLeft, Color.red, 7);

        returnbtn = new ButtonSetting(return_btn, 1.5f, 0.1f, 0.6f, 0.15f, new ReturnOnClick().onClick);
        returnbtn.function(textFont, FontStyle.Normal, "上一頁", TextAnchor.MiddleCenter, Color.black, 7);
    }

    public float sizeX, sizeY;

    private void FixedUpdate()
    {
        try
        {
            /*START_HOUR_TYPE = startHourInput.getMessage();
            START_MINUTE_TYPE = startMinuteInput.getMessage();*/

            /*END_HOUR_TYPE = endHourInput.getMessage();
            END_MINUTE_TYPE = endMinuteInput.getMessage();*/

            result.function(textFont, FontStyle.Normal, Calculate.RESULT(), TextAnchor.MiddleLeft, Color.red, 7);
        }
        catch { }
    }
}
