using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyHoursLayout : MonoBehaviour
{
    public Image breakGroudArea_Image;

    // 說明
    public Image instructionBreakGroud_Image;
    public Text instructionMessage_Text;
    public Image weekDayBreakGroud_Image;
    public RectTransform weekArea_RectTransform;

    #region 週次
    // 星期一
    public RectTransform mondayManage_RectTransform;
    public Text mondayMessage_Text;
    public Text mHour_Text;
    public InputField mHourInput_InputField;
    public Text mMinute_Text;
    public InputField mMinuteInput_InputField;
    public Text mCycle_Text;
    public InputField mCycleInput_InputField;
    public Text mHoliday_Text;
    public InputField mHolidayInput_InputField;

    // 星期二
    public RectTransform tuesdayManage_RectTransform;
    public Text tuesdayMessage_Text;
    public Text tHour_Text;
    public InputField tHourInput_InputField;
    public Text tMinute_Text;
    public InputField tMinuteInput_InputField;
    public Text tCycle_Text;
    public InputField tCycleInput_InputField;
    public Text tHoliday_Text;
    public InputField tHolidayInput_InputField;

    // 星期三
    public RectTransform wednesdayManage_RectTransform;
    public Text wednesdayMessage_Text;
    public Text wHour_Text;
    public InputField wHourInput_InputField;
    public Text wMinute_Text;
    public InputField wMinuteInput_InputField;
    public Text wCycle_Text;
    public InputField wCycleInput_InputField;
    public Text wHoliday_Text;
    public InputField wHolidayInput_InputField;

    // 星期四
    public RectTransform thursdayManage_RectTransform;
    public Text thursdayMessage_Text;
    public Text thHour_Text;
    public InputField thHourInput_InputField;
    public Text thMinute_Text;
    public InputField thMinuteInput_InputField;
    public Text thCycle_Text;
    public InputField thCycleInput_InputField;
    public Text thHoliday_Text;
    public InputField thHolidayInput_InputField;

    // 星期五
    public RectTransform fridayManage_RectTransform;
    public Text fridayMessage_Text;
    public Text fHour_Text;
    public InputField fHoutInput_InputField;
    public Text fMinute_Text;
    public InputField fMinuteInput_InputField;
    public Text fCycle_Text;
    public InputField fCycleInput_InputField;
    public Text fHoliday_Text;
    public InputField fHolidayInput_InputField;

    // 星期六
    public RectTransform saturdayManage_RectTransform;
    public Text saturdayMessage_Text;
    public Text sHour_Text;
    public InputField sHourInput_InputField;
    public Text sMinute_Text;
    public InputField sMinuteInput_InputField;
    public Text sCycle_Text;
    public InputField sCycleInput_InputField;
    public Text sHoliday_Text;
    public InputField sHolidayInput_InputField;

    // 星期日
    public RectTransform sundayManage_RectTransform;
    public Text sundayMessage_Text;
    public Text suHour_Text;
    public InputField suHourInput_InputField;
    public Text suMinute_Text;
    public InputField suMinuteInput_InputField;
    public Text suCycle_Text;
    public InputField suCycleInput_InputField;
    public Text suHoliday_Text;
    public InputField suHolidayInput_InputField;

    // 加班
    public RectTransform workOvertimeManage_RectTransform;
    public Text workOvertimeMessage_Text;
    public Text workOvertimeHour_Text;
    public InputField workOvertimeHourInput_InputField;
    public Text workOvertimeMinute_Text;
    public InputField workOvertimeMinuteInput_InputField;
    #endregion

    // 結果
    public Image resultBreakGroud_Image;
    ImageSetting resultBreakGroud;
    public Text resultMessage_Maessage;
    TextSetting resultMessage;

    // 系統訊息
    public Text systemMessage_Text;

    // 年
    public Text year_Text;
    public InputField yearInput_InputField;

    // 月
    public Text month_Text;
    public InputField monthInput_InputField;

    // 按鈕
    public Button return_Button;
    ButtonSetting returnBtn;
    public Button calculate_Button;
    ButtonSetting calculateBtn;

    WeekInterface breakGroud;

    public static WeekInterface MONDAY, TUESDAY, WENDESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY, WORKOVERTIME;
    public static WeekInterface SYSTEM_YEAR;

    public Font textFont;

    ~WeeklyHoursLayout()
    {
        CalculateOnClick.RESULT_MESSAGE = "";
    }

    private void Start()
    {
        // 背景
        breakGroud = new WeekInterface(breakGroudArea_Image, instructionBreakGroud_Image, weekDayBreakGroud_Image,
            instructionMessage_Text, weekArea_RectTransform);
        breakGroud.breakGroud_Layout(instructionResult());

        // 週期(週次)
        weekCycle();

        // 結果區域背景
        resultBreakGroud = new ImageSetting(resultBreakGroud_Image, 1, 0.34f, 1.59f, 0.27f);
        resultBreakGroud.function(null, false, true, resultMessage_Maessage.rectTransform);
        resultMessage_Maessage.transform.parent = resultBreakGroud_Image.transform;

        // 顯示結果
        resultMessage = new TextSetting(resultMessage_Maessage, 0, 0, 0, 0);
        resultMessage.function(7, "", Vector2.zero, new Vector2(1, 1), new Vector2(0.5f, 1f));

        // 系統訊息
        SYSTEM_YEAR = new WeekInterface(systemMessage_Text, year_Text, yearInput_InputField, month_Text, monthInput_InputField);
        SYSTEM_YEAR.system_Layout(textFont, 0.78f, "週次計算");

        // 按鈕
        returnBtn = new ButtonSetting(return_Button, 1.5f, 0.1f, 0.6f, 0.15f, new ReturnOnClick().onClick);
        returnBtn.function(textFont, FontStyle.Normal, "上一頁", TextAnchor.MiddleCenter, Color.black, 7);
        calculateBtn = new ButtonSetting(calculate_Button, 0.5f, 0.1f, 0.6f, 0.15f, new CalculateOnClick().onClick);
        calculateBtn.function(textFont, FontStyle.Normal, "計算", TextAnchor.MiddleCenter, Color.black, 7);
    }

    private void FixedUpdate()
    {
        try
        {
            Vector2 sizeDelta = (CalculateOnClick.RESULT_MESSAGE.Length == 0) ? new Vector2(0, 0) :
                new Vector2(0, Screen.height / 2 * 0.65f);
            resultMessage_Maessage.GetComponent<RectTransform>().sizeDelta = sizeDelta;

            resultMessage.setMessage("結果" + CalculateOnClick.RESULT_MESSAGE);
        }
        catch { }
    }

    // 週期(週次)
    void weekCycle()
    {
        // weekArea_RectTransform 物件底下子物件: 週次
        mondayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        tuesdayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        wednesdayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        thursdayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        fridayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        saturdayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        sundayManage_RectTransform.transform.parent = weekArea_RectTransform.transform;
        workOvertimeManage_RectTransform.transform.parent = weekArea_RectTransform.transform;

        MONDAY = new WeekInterface(mondayManage_RectTransform, mondayMessage_Text, mHour_Text, mHourInput_InputField,
            mMinute_Text, mMinuteInput_InputField, mCycle_Text, mCycleInput_InputField, mHoliday_Text, mHolidayInput_InputField);
        MONDAY.week_Layout(textFont, 1.2f, "週一");
        mCycleInput_InputField.enabled = false;

        TUESDAY = new WeekInterface(tuesdayManage_RectTransform, tuesdayMessage_Text, tHour_Text, tHourInput_InputField, tMinute_Text,
            tMinuteInput_InputField, tCycle_Text, tCycleInput_InputField, tHoliday_Text, tHolidayInput_InputField);
        TUESDAY.week_Layout(textFont, 0.56f, "週二");
        tCycleInput_InputField.enabled = false;

        WENDESDAY = new WeekInterface(wednesdayManage_RectTransform, wednesdayMessage_Text, wHour_Text, wHourInput_InputField,
            wMinute_Text, wMinuteInput_InputField, wCycle_Text, wCycleInput_InputField, wHoliday_Text, wHolidayInput_InputField);
        WENDESDAY.week_Layout(textFont, -0.08f, "週三");
        wCycleInput_InputField.enabled = false;

        THURSDAY = new WeekInterface(thursdayManage_RectTransform, thursdayMessage_Text, thHour_Text, thHourInput_InputField,
            thMinute_Text, thMinuteInput_InputField, thCycle_Text, thCycleInput_InputField, thHoliday_Text, thHolidayInput_InputField);
        THURSDAY.week_Layout(textFont, -0.72f, "週四");
        tCycleInput_InputField.enabled = false;

        FRIDAY = new WeekInterface(fridayManage_RectTransform, fridayMessage_Text, fHour_Text, fHoutInput_InputField, fMinute_Text,
            fMinuteInput_InputField, fCycle_Text, fCycleInput_InputField, fHoliday_Text, fHolidayInput_InputField);
        FRIDAY.week_Layout(textFont, -1.36f, "週五");
        fCycleInput_InputField.enabled = false;

        SATURDAY = new WeekInterface(saturdayManage_RectTransform, saturdayMessage_Text, sHour_Text, sHourInput_InputField,
            sMinute_Text, sMinuteInput_InputField, sCycle_Text, sCycleInput_InputField, sHoliday_Text, sHolidayInput_InputField);
        SATURDAY.week_Layout(textFont, -2f, "週六");
        sCycleInput_InputField.enabled = false;

        SUNDAY = new WeekInterface(sundayManage_RectTransform, sundayMessage_Text, suHour_Text, suHourInput_InputField, suMinute_Text,
            suMinuteInput_InputField, suCycle_Text, suCycleInput_InputField, suHoliday_Text, suHolidayInput_InputField);
        SUNDAY.week_Layout(textFont, -2.64f, "週日");
        suCycleInput_InputField.enabled = false;

        WORKOVERTIME = new WeekInterface(workOvertimeManage_RectTransform, workOvertimeMessage_Text, workOvertimeHour_Text,
            workOvertimeHourInput_InputField, workOvertimeMinute_Text, workOvertimeMinuteInput_InputField);

        WORKOVERTIME.workOvertime_Layout(textFont, -3.28f, "加班");
    }

    // 說明內容
    string instructionResult()
    {
        return "說明:\n週次經由使用者設定月\n份計算，一週日期週期。\n例如: 2022年1月擁有5\n個星期一。";
    }
}