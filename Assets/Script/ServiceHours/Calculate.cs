using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate
{

    // 小時換成分
    static int hourToMinute(int hour, int minute)
    {
        if (hour <= 0)
            return 0 + minute;

        int conversion = (hour * 60) + minute;

        return conversion;
    }

    // 小時
    static int timeCalculate(int times, int service)
    {
        return times * service;
    }

    
    static int resultMinute(int hour, int minute)
    {
        return (60 - hour) + minute; 
    }

    static int conversion(int serviceHours, int selectStaus)
    {
        if (selectStaus.Equals(1))
            return serviceHours / 60;
        else if (selectStaus.Equals(2))
            return serviceHours % 60;

        return 0;
    }

    public static string RESULT()
    {
        int result_hourt, result_minute;

        if (resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue()) < 60)
        {
            result_hourt = (ServiceHoursLayout.END_SERVICE.getHourValue() - ServiceHoursLayout.START_SERVICE.getHourValue()) - 1;
            result_minute = resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue());

            int serviesHour = timeCalculate(result_hourt, ServiceHoursLayout.SERVICE_VALUE.getServiceValue()) +
                conversion(timeCalculate(result_minute, ServiceHoursLayout.SERVICE_VALUE.getServiceValue()), 1);

            int serviesMinute = conversion(timeCalculate(result_minute, ServiceHoursLayout.SERVICE_VALUE.getServiceValue()), 2);


            if (result_hourt < -1)
                return "目前沒有做到凌晨計算哦~!";

            return "結果:\n" + result_hourt + "小時" + result_minute + "分鐘"
                + "\n服務次數結果:\n" + serviesHour + "小時 " + serviesMinute + "分鐘";
        }

        if (resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue()) == 60)
        {

            result_hourt = ServiceHoursLayout.END_SERVICE.getHourValue() - ServiceHoursLayout.START_SERVICE.getHourValue();
            int minute = conversion(resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue()), 2);

            // 服務次數
            int serviesHour = timeCalculate(result_hourt, ServiceHoursLayout.SERVICE_VALUE.getServiceValue());

            if (result_hourt < -1)
                return "目前沒有做到凌晨計算哦~!";

            return "結果:\n" + result_hourt + "小時" + minute + "分鐘\n" +
                "\n服務次數:\n" + serviesHour + "小時" + minute + "分鐘";
        }

        if (resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue()) > 60)
        {
            result_hourt = (ServiceHoursLayout.END_SERVICE.getHourValue() - ServiceHoursLayout.START_SERVICE.getHourValue()) - 1;
            int minute = resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue()) % 60;
            int hourt = resultMinute(ServiceHoursLayout.START_SERVICE.getMinuteValue(), ServiceHoursLayout.END_SERVICE.getMinuteValue()) / 60;


            int serviesHour = timeCalculate((result_hourt + hourt), ServiceHoursLayout.SERVICE_VALUE.getServiceValue()) +
                conversion(timeCalculate(minute, ServiceHoursLayout.SERVICE_VALUE.getServiceValue()), 1);

            int serviesMinute = conversion(timeCalculate(minute, ServiceHoursLayout.SERVICE_VALUE.getServiceValue()), 2);


            if (result_hourt < -1)
                return "目前沒有做到凌晨計算哦~!";

            return "結果:\n" + (result_hourt + hourt) + "小時 " + minute + "分鐘" +
                "\n服務次數結果:\n" + serviesHour + "小時 " + serviesMinute + "分鐘";
        }

        return "";
    }

}
