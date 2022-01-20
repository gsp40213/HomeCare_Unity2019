using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate
{
    static int RESULT_MINUTE()
    {
        return (60 - ServiceHoursLayout.START_SERVICE.getMinuteValue()) + ServiceHoursLayout.END_SERVICE.getMinuteValue(); 
    }

    public static string RESULT()
    {
        int result_hourt = 0;

        if (RESULT_MINUTE() < 60)
        {
            result_hourt = (ServiceHoursLayout.END_SERVICE.getHourValue() - ServiceHoursLayout.START_SERVICE.getHourValue()) - 1;  

            if (result_hourt < -1)
                return "目前沒有做到凌晨計算哦~!";

            return result_hourt + "小時\t" + RESULT_MINUTE() + "分鐘";
        }

        if (RESULT_MINUTE() == 60)
        {

            result_hourt = ServiceHoursLayout.END_SERVICE.getHourValue() - ServiceHoursLayout.START_SERVICE.getHourValue();

            if (result_hourt < -1)
                return "目前沒有做到凌晨計算哦~!";

            return "結果: " + result_hourt + "小時\t" + 0 + "分鐘";
        }

        if (RESULT_MINUTE() > 60)
        {
            result_hourt = (ServiceHoursLayout.END_SERVICE.getHourValue() - ServiceHoursLayout.START_SERVICE.getHourValue()) - 1;
            int minute = RESULT_MINUTE() % 60;
            int hourt = RESULT_MINUTE() / 60;

            if (result_hourt < -1)
                return "目前沒有做到凌晨計算哦~!";

            return "結果: " + (result_hourt + hourt) + "小時\t" + minute + "分鐘";
        }

        return "";
    }

}
