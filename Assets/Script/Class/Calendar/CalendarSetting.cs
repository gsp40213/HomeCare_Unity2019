using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CalendarSetting : Calendar
{
    public CalendarSetting(int year, int month, int day) : base(year, month, day) { }

    DateTime startdate;

    public override int readMonthWeekNum(string weekName)
    {
        startdate = new DateTime(year, month, day);
        int frequency = 0;

        for (int x = day; x <= DateTime.DaysInMonth(startdate.Year, startdate.Month); x++)
        {
            startdate = new DateTime(startdate.Year, startdate.Month, x);
            if (weekEngToChin(startdate.DayOfWeek.ToString()) == weekName)
                frequency += 1;
        }

        return frequency;
    }

    // 西元轉換民國 (公式)
    string vidToRepublic(int dayofYear)
    {
        int vidNumber = 1911; // 公式

        int sum = dayofYear - vidNumber;

        return sum.ToString();
    }

    // 英文轉中文(星期)
    string weekEngToChin(string dayOfWeek)
    {
        string chinWeek = "";

        if (dayOfWeek.ToString().Equals("Monday"))
            chinWeek = "星期一";
        if (dayOfWeek.ToString().Equals("Tuesday"))
            chinWeek = "星期二";
        if (dayOfWeek.ToString().Equals("Wednesday"))
            chinWeek = "星期三";
        if (dayOfWeek.ToString().Equals("Thursday"))
            chinWeek = "星期四";
        if (dayOfWeek.ToString().Equals("Friday"))
            chinWeek = "星期五";
        if (dayOfWeek.ToString().Equals("Saturday"))
            chinWeek = "星期六";
        if (dayOfWeek.ToString().Equals("Sunday"))
            chinWeek = "星期日";

        return chinWeek;
    }

}
