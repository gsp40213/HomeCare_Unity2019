using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeConversionCalculation
{
    public static string RESULT()
    {
        return "結果: " + CONVERSION(HOUR_TO_MINUTE(TimeConversionLayout.HOUR_MINUTE.getHourValue(), 
            TimeConversionLayout.HOUR_MINUTE.getMinuteValue()), 1).ToString() + "小時"
             + CONVERSION(HOUR_TO_MINUTE(TimeConversionLayout.HOUR_MINUTE.getHourValue(),
             TimeConversionLayout.HOUR_MINUTE.getMinuteValue()), 2).ToString() + "分鐘";
    }

    static int CONVERSION(int serviceHours, int selectStaus)
    {
        if (selectStaus.Equals(1))
            return serviceHours / 60;
        else if (selectStaus.Equals(2))
            return serviceHours % 60;

        return 0;
    }

    // 小時換成分
    static int HOUR_TO_MINUTE(int hour, int minute)
    {
        if (hour <= 0)
            return 0 + minute;

        int conversion = (hour * 60) + minute;

        return conversion;
    }
}
