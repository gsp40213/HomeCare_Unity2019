using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeklyHoursCalculate
{
    private int hour;
    private int minute;
    private int cycle;
    private int holiday;

    public WeeklyHoursCalculate(int hour, int minute, int cycle, int holiday)
    {
        this.hour = hour;
        this.minute = minute;
        this.cycle = cycle;
        this.holiday = holiday;
    }

    // 每週時間，不含加班_小時
    public string revesult_weekly_Hour()
    {
        int hourCalculateResult = hourCalculate(hour, cycle, holiday);
        int minuteCalculateResult = minuteCalculate(minute, cycle, holiday);

        return conversion(hourToMinute(hourCalculateResult, minuteCalculateResult), 1).ToString();
    }

    // 每週時間，不含加班_分鐘
    public string result_weekly_minute()
    {
        int hourCalculateResult = hourCalculate(hour, cycle, holiday);
        int minuteCalculateResult = minuteCalculate(minute, cycle, holiday);

        return conversion(hourToMinute(hourCalculateResult, minuteCalculateResult), 2).ToString();
    }

    // 累計時數
    public string result_total()
    {

        int hour = GRANDTOTAL_HOUR();
        int minute = GRANDTOTAL_MIMUTE();

        return conversion(hourToMinute(hour, minute), 1) + "小時" +
            conversion(hourToMinute(hour, minute), 2) + "分鐘";
    }

    // 累計_小時
    int GRANDTOTAL_HOUR()
    {
        int totalHour = 0;

        for (int x = 0; x < CalculateOnClick.WEEKDATATIMES.Count; x++)
            totalHour += CalculateOnClick.WEEKDATATIMES[x].hour;

        totalHour += WeeklyHoursLayout.WORKOVERTIME.getHourValue();

        return totalHour;
    }

    // 累計_分鐘;
    int GRANDTOTAL_MIMUTE()
    {
        int totalHour = 0;

        for (int x = 0; x < CalculateOnClick.WEEKDATATIMES.Count; x++)
            totalHour += CalculateOnClick.WEEKDATATIMES[x].minute;

        totalHour += WeeklyHoursLayout.WORKOVERTIME.getMinuteValue();

        return totalHour;
    }
    int conversion(int serviceHours, int selectStaus)
    {
        if (selectStaus.Equals(1))
            return serviceHours / 60;
        else if (selectStaus.Equals(2))
            return serviceHours % 60;

        return 0;
    }

    // 小時換成分
    int hourToMinute(int hour, int minute)
    {
        if (hour <= 0)
            return 0 + minute;

        int conversion = (hour * 60) + minute;

        return conversion;
    }

    // 小時
    int hourCalculate(int hour, int cycle, int HOLIDAY)
    {

        return (hour * (cycle - HOLIDAY));
    }

    // 分鐘
    public int minuteCalculate(int minute, int cycle, int HOLIDAY)
    {
        return (minute * (cycle - HOLIDAY));
    }
}

public class weekHour
{
    int hour, minute;
    public weekHour(int hour, int minute)
    {
        this.hour = hour;
        this.minute = minute;
    }
}
