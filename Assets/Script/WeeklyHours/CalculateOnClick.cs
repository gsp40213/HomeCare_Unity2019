using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CalculateOnClick : OnClick
{
    CalendarSetting calendarSetting;

    WeeklyHoursCalculate monday;
    WeeklyHoursCalculate tuesday;
    WeeklyHoursCalculate wednesday;
    WeeklyHoursCalculate thursday;
    WeeklyHoursCalculate friday;
    WeeklyHoursCalculate saturday;
    WeeklyHoursCalculate sunday;

    // 累計
    WeeklyHoursCalculate total = new WeeklyHoursCalculate(0, 0, 0, 0);

    public static List<WeekDataTime> WEEKDATATIMES = new List<WeekDataTime>();

    public static string RESULT_MESSAGE = "";

    public void onClick()
    {
        WEEKDATATIMES.Clear();
        
        calendarSetting = new CalendarSetting(WeeklyHoursLayout.SYSTEM_YEAR.getYearValue(), 
            WeeklyHoursLayout.SYSTEM_YEAR.getMonthValue(), 1); 

        WeeklyHoursLayout.MONDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期一"));
        WeeklyHoursLayout.TUESDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期二"));
        WeeklyHoursLayout.WENDESDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期三"));
        WeeklyHoursLayout.THURSDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期四"));
        WeeklyHoursLayout.FRIDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期五"));
        WeeklyHoursLayout.SATURDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期六"));
        WeeklyHoursLayout.SUNDAY.setCycleValue(calendarSetting.readMonthWeekNum("星期日"));        

        // 顯示計算結果
        monday = new WeeklyHoursCalculate(WeeklyHoursLayout.MONDAY.getHourValue(), WeeklyHoursLayout.MONDAY.getMinuteValue(),
            WeeklyHoursLayout.MONDAY.getCycleValue(), WeeklyHoursLayout.MONDAY.getHoliday());

        tuesday = new WeeklyHoursCalculate(WeeklyHoursLayout.TUESDAY.getHourValue(), WeeklyHoursLayout.TUESDAY.getMinuteValue(),
            WeeklyHoursLayout.TUESDAY.getCycleValue(), WeeklyHoursLayout.TUESDAY.getHoliday());

        wednesday = new WeeklyHoursCalculate(WeeklyHoursLayout.WENDESDAY.getHourValue(), WeeklyHoursLayout.WENDESDAY.getMinuteValue(),
            WeeklyHoursLayout.WENDESDAY.getCycleValue(), WeeklyHoursLayout.WENDESDAY.getHoliday());

        thursday = new WeeklyHoursCalculate(WeeklyHoursLayout.THURSDAY.getHourValue(), WeeklyHoursLayout.THURSDAY.getMinuteValue(),
            WeeklyHoursLayout.THURSDAY.getCycleValue(), WeeklyHoursLayout.THURSDAY.getHoliday());

        friday = new WeeklyHoursCalculate(WeeklyHoursLayout.FRIDAY.getHourValue(), WeeklyHoursLayout.FRIDAY.getMinuteValue(),
            WeeklyHoursLayout.FRIDAY.getCycleValue(), WeeklyHoursLayout.FRIDAY.getHoliday());

        saturday = new WeeklyHoursCalculate(WeeklyHoursLayout.SATURDAY.getHourValue(), WeeklyHoursLayout.SATURDAY.getMinuteValue(),
            WeeklyHoursLayout.SATURDAY.getCycleValue(), WeeklyHoursLayout.SATURDAY.getHoliday());

        sunday = new WeeklyHoursCalculate(WeeklyHoursLayout.SUNDAY.getHourValue(), WeeklyHoursLayout.SUNDAY.getMinuteValue(),
            WeeklyHoursLayout.SUNDAY.getCycleValue(), WeeklyHoursLayout.SUNDAY.getHoliday());

        weekDataListAdd();    

        string str = "\n週一: " + monday.revesult_weekly_Hour() + "小時" + monday.result_weekly_minute() + "分鐘" +
                     "\n週二:" + tuesday.revesult_weekly_Hour() + "小時" + tuesday.result_weekly_minute() + "分鐘" +
                     "\n週三: " + wednesday.revesult_weekly_Hour() + "小時" + wednesday.result_weekly_minute() + "分鐘" +
                     "\n週四: " + thursday.revesult_weekly_Hour() + "小時" + thursday.result_weekly_minute() + "分鐘" +
                     "\n週五: " + friday.revesult_weekly_Hour() + "小時" + friday.result_weekly_minute() + "分鐘" +
                     "\n週六: " + saturday.revesult_weekly_Hour() + "小時" + saturday.result_weekly_minute() + "分鐘" +
                     "\n週日: " + sunday.revesult_weekly_Hour() + "小時" + sunday.result_weekly_minute() + "分鐘" +
                     "\n加班: " + WeeklyHoursLayout.WORKOVERTIME.getHourValue() + "小時 " + WeeklyHoursLayout.WORKOVERTIME.getMinuteValue() + "分鐘" +
                     "\n累計: " + total.result_total();

        RESULT_MESSAGE = str;

    }

    // 數據加入Add
    void weekDataListAdd()
    {
        WEEKDATATIMES.Add(new WeekDataTime(monday.revesult_weekly_Hour(), monday.result_weekly_minute()));
        WEEKDATATIMES.Add(new WeekDataTime(tuesday.revesult_weekly_Hour(), tuesday.result_weekly_minute()));
        WEEKDATATIMES.Add(new WeekDataTime(wednesday.revesult_weekly_Hour(), wednesday.result_weekly_minute()));
        WEEKDATATIMES.Add(new WeekDataTime(thursday.revesult_weekly_Hour(), thursday.result_weekly_minute()));
        WEEKDATATIMES.Add(new WeekDataTime(friday.revesult_weekly_Hour(), friday.result_weekly_minute()));
        WEEKDATATIMES.Add(new WeekDataTime(saturday.revesult_weekly_Hour(), saturday.result_weekly_minute()));
        WEEKDATATIMES.Add(new WeekDataTime(sunday.revesult_weekly_Hour(), sunday.result_weekly_minute()));
    }
}

public class WeekDataTime
{
    public int hour, minute;
    public WeekDataTime(string hour, string minute)
    {
        this.hour = Int32.Parse(hour);
        this.minute = Int32.Parse(minute);
    }
}
