using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Calendar
{
    protected int year, month, day;
    public Calendar(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public abstract int readMonthWeekNum(string weekName);
}