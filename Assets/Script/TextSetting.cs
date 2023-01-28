using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetting : UIOBJ.Text_Setting
{
    public TextSetting(Text text, float pointX, float pointY, float sizeX, float sizeY, string message, int textSize) :
        base(text, pointX, pointY, sizeX, sizeY, message, textSize)
    {
        // text point/Size
        text.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        text.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);

        // text message/textSize
        text.text = message;
        text.fontSize = Screen.width / 2 / textSize;
    }

    public override void messageText(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color, string message)
    {
        text.text = message;

        text.font = font;
        text.fontStyle = fontStyle;
        text.alignment = textAnchor;
        text.color = color;
    }

    public override void style(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color)
    {
        text.font = font;
        text.fontStyle = fontStyle;
        text.alignment = textAnchor;
        text.color = color;
    }

    public override void areaText(Vector2 anchorsMin, Vector2 anchorsMax, Vector2 pivot)
    {
        // area setting
        AreaSetting areaFunction = new AreaSetting(text.GetComponent<RectTransform>(), anchorsMin, anchorsMax, pivot);
        areaFunction.defaultFunction(new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY));

        // text horizontal/vertical setting
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.verticalOverflow = VerticalWrapMode.Truncate;
    }

    /// <summary>
    /// set message Function
    /// </summary>
    /// <param message="string"></param>
    public void setMessage(string message)
    {
        text.text = message;
    }

    /// <summary>
    /// get message Function
    /// </summary>
    /// <returns></returns>
    public string getMessage()
    {
        return text.text;
    }
}