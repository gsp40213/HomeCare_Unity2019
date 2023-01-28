using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSetting : UIOBJ.InputField_Setting
{
    public InputFieldSetting(InputField inputField, float pointX, float pointY, float sizeX, float sizeY, InputField.ContentType contentType) :
        base(inputField, pointX, pointY, sizeX, sizeY, contentType)
    { 
        inputField.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        inputField.image.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);
        inputField.contentType = contentType;
    }

    public override void textStyle(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color, int textSize)
    {
        Text text = inputField.transform.GetChild(1).GetComponent<Text>();

        text.font = font;
        text.fontStyle = fontStyle;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;
    }

    /// <summary>
    /// setMessage Function
    /// </summary>
    /// <param message="string"></param>
    public void setMessage(string message)
    {
        inputField.text = message;
    }

    /// <summary>
    /// getMessage Function
    /// </summary>
    /// <returns></returns>
    public string getMessage()
    {
        return inputField.text;
    }
}