using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnClickView : CalculatoOnClck
{
    private static List<double> INPUT_NUM = new List<double>();
    private static string NUMBER;
    private bool active = false;

    private static string CHEAR_MESSAGE;
    private static int CHEAR_STATUS;

    // 顯示計算過程
    private static string RESUL_MESSAGE;


    ~OnClickView()
    {
        CHEAR_STATUS = 0;
        active = false;
        INPUT_NUM.Clear();
        RESUL_MESSAGE = "";
        NUMBER = "";
    }

    // 計算過程
    public static string RESULT_MESSAGE()
    {
        return RESUL_MESSAGE;
    }

    // 清除
    public void chearClick()
    {
        CHEAR_STATUS = 0;
        active = false;
        INPUT_NUM.Clear();
        RESUL_MESSAGE = "";
        NUMBER = "";
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
            RESUL_MESSAGE = "0";
            active = false;
        }

        NUMBER += conNumber;
        RESUL_MESSAGE += conNumber;
    }

    // 數學符號
    void chearMessage(string chear)
    {
        active = true;
        INPUT_NUM.Add(double.Parse(NUMBER));
        NUMBER = "0";
   
        CHEAR_MESSAGE = chear;

        if (RESUL_MESSAGE.Substring(RESUL_MESSAGE.Length) != CHEAR_MESSAGE)
            RESUL_MESSAGE += CHEAR_MESSAGE;
    }

    // 加
    public void addClick()
    {
        chearMessage("+");
        CHEAR_STATUS = 1;
    }

    // 减
    public void reduceClick()
    {
        chearMessage("-");
        CHEAR_STATUS = 2;
    }

    // 乘
    public void takeClick()
    {
        chearMessage("×");
        CHEAR_STATUS = 3;
    }

    // 除法
    public void removeClick()
    {
        chearMessage("÷");
        CHEAR_STATUS = 4;
    }

    double number;

    // 等於
    public void equalClick()
    {
        if (CHEAR_STATUS == 1)
        {
            INPUT_NUM.Add(double.Parse(NUMBER));
            number = INPUT_NUM.Aggregate((m, n) => m + n);    
        }

        if (CHEAR_STATUS == 2)
        {
            INPUT_NUM.Add(double.Parse(NUMBER));
            number = INPUT_NUM.Aggregate((m, n) => m - n);         
        }


        if (CHEAR_STATUS == 3)
        {
            INPUT_NUM.Add(double.Parse(NUMBER));
            number = INPUT_NUM.Aggregate((m, n) => m * n);
        }

        if (CHEAR_STATUS == 4)
        {
            INPUT_NUM.Add(double.Parse(NUMBER));
            number = INPUT_NUM.Aggregate((m, n) => m / n);
        }

        RESUL_MESSAGE = number.ToString();     
    }
}
