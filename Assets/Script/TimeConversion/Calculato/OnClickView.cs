using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnClickView : CalculatoOnClck
{
    private bool active = false;

    // 顯示計算過程
    private static string PROCESS, RESULT, VALUE;

    private static double A, SUM;
    private static string CHEAR_MESSAGE;  //CHEAR_MESSAGE;
    private static int CHEAR_STATUS;    // CHEAR_STATUS

    ~OnClickView()
    {
        CHEAR_STATUS = 0;
        active = false;
        PROCESS = "";
        RESULT = "";
        VALUE = null;
    }

    // 計算過程
    public static string RESULT_PROCESS()
    {
        return "過程: " + PROCESS;
    }

    // 計算結果
    public static string RESULT_()
    {
        return "結果:" + RESULT;
    }

    // 清除
    public void chearClick()
    {
        CHEAR_STATUS = 0;
        active = false;
        PROCESS = "";
        RESULT = "";
        VALUE = null;
    }

    public void eightClick()
    {
        numberMessage(8);
    }

    public void fiveClick()
    {
        numberMessage(5);
    }

    public void fourClick()
    {
        numberMessage(4);
    }

    public void nineClick()
    {
        numberMessage(9);
    }

    public void sevenClick()
    {
        numberMessage(7);
    }

    public void sixClick()
    {
        numberMessage(6);
    }

    public void threeClick()
    {
        numberMessage(3);
    }

    public void twoClick()
    {
        numberMessage(2);
    }

    public void zeroClick()
    {
        numberMessage(0);
    }

    public void oneClick()
    {
        numberMessage(1);
    }

    // 數字訊息
    void numberMessage(double conNumber)
    {
        if (active == true)
        {
            PROCESS = "0";
            active = false;
        }

        if (RESULT == null || RESULT == "")
            PROCESS += conNumber;
        else
            PROCESS = RESULT + CHEAR_MESSAGE + conNumber;

        VALUE += conNumber;
    }

    // 數學符號
    void chear(string chear)
    {
        active = true;
        CHEAR_MESSAGE = chear;

        if (PROCESS.Substring(PROCESS.Length) != CHEAR_MESSAGE)
            PROCESS += CHEAR_MESSAGE;
    }

    // 加
    public void addClick()
    {
        chear("+");
        CHEAR_STATUS = 1;

        if (RESULT == null || RESULT == "")
            A = double.Parse(VALUE);
        else
            A = double.Parse(RESULT);

        VALUE = "0";
    }

    // 减
    public void reduceClick()
    {
        chear("-");
        CHEAR_STATUS = 2;

        if (RESULT == null || RESULT == "")
            A = double.Parse(VALUE);
        else A = double.Parse(RESULT);

        VALUE = "0";
    }

    // 乘
    public void takeClick()
    {
        chear("×");
        CHEAR_STATUS = 3;

        if (RESULT == null || RESULT == "")
            A = double.Parse(VALUE);
        else A = double.Parse(RESULT);

        VALUE = "0";
    }

    // 除法
    public void removeClick()
    {
        chear("÷");
        CHEAR_STATUS = 4;

        if (RESULT == null || RESULT == "")
            A = double.Parse(VALUE);
        else A = double.Parse(RESULT);

        VALUE = "0";
    }

    double number;

    // 等於
    public void equalClick()
    {
        if (CHEAR_STATUS == 1)
            SUM = A + double.Parse(VALUE);

        if (CHEAR_STATUS == 2)
            SUM = A - double.Parse(VALUE);

        if (CHEAR_STATUS == 3)
            SUM = A * double.Parse(VALUE);

        if (CHEAR_STATUS == 4)
            SUM = A / double.Parse(VALUE);

        RESULT = SUM.ToString();
    }
}