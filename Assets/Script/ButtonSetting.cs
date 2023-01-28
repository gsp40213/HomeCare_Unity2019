using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonSetting : UIOBJ.ButtonSetting
{
    public ButtonSetting(Button button, float pointX, float pointY, float sizeX, float sizeY, UnityAction onClick) :
     base(button, pointX, pointY, sizeX, sizeY, onClick)
    {
        // button point/Size
        button.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        button.image.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);
    }

    /// <summary>
    /// image_Button Function
    /// </summary>
    /// <param image="Sprite"></param>
    /// <param color="Color" name="white"></param>
    /// <param rayTarget="bool" name="true", default: true></param>
    /// <param maskable="bool" name="true", default: true></param>
    /// <param type="Image.Type" name="Sliced", default: simple></param>
    /// <param childNum="int"></param>
    /// <returns></returns>
    public override void image(Sprite image, Color color, bool rayTarget, bool maskable, Image.Type type, int childNum)
    {
        button.image.sprite = image;
        button.image.color = color;
        button.image.raycastTarget = rayTarget;
        button.image.maskable = maskable;
        button.image.type = type;

        Text text = button.transform.GetChild(childNum).GetComponent<Text>();
        text.text = "";
    }

    /// <summary>
    /// textTyoe Function
    /// </summary>
    /// <param font="Font"></param>
    /// <param fontStyle="FontStyle"></param>
    /// <param message="string"></param>
    /// <param textAnchor="TextAnchor"></param>
    /// <param color="Color"></param>
    /// <param textSize="int"></param>
    /// <returns></returns>
    public override void textStype(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color, int textSize, int childNum)
    {
        Text text = button.transform.GetChild(childNum).GetComponent<Text>();
        text.font = font;
        text.fontStyle = fontStyle;
        text.text = message;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;

        // button activity
        button.onClick.AddListener(onClick);
    }

    /// <summary>
    /// button activity
    /// </summary>
    /// <param activity="bool"></param>
    public void setInteracTable(bool activity)
    {
        button.interactable = activity;
    }

    public bool setInteracTable()
    {
        return button.interactable;
    }
}