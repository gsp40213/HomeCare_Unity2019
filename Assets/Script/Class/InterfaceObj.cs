using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InterfaceObj
{
    protected Text message;
    protected InputField inputFiled;
    protected Font font;

    public InterfaceObj(Text message, InputField inputFiled, Font font)
    {
        this.message = message;
        this.inputFiled = inputFiled;
        this.font = font;
    }

    public abstract void dateWeekfunction(string textMessage, float pointY);
    public abstract void funtcionHoliday(string textMessage, float pointY);

    public abstract void systemAndYear(string textMessage, float pointX);
}