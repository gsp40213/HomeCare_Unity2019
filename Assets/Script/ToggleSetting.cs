using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSetting : UIOBJ.Toggle_Setting
{
    public ToggleSetting(Toggle toggle, Sprite breakGroud, Sprite checkmark, float pointX, float pointY) :
        base(toggle, breakGroud, checkmark, pointX, pointY)
    {
        toggle.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.width / 2 * pointY);
    }

    public override void breakGroud_ImageType(Color color, bool rayTarget, bool maskable, Image.Type type, int childNum)
    {
        Image breakGroud = toggle.transform.GetChild(childNum).GetComponent<Image>();
        breakGroud.sprite = base.breakGroud;
        breakGroud.color = color;
        breakGroud.raycastTarget = rayTarget;
        breakGroud.maskable = maskable;
        breakGroud.type = type;
    }

    public override void checkmark_ImageType(Color color, bool rayTarget, bool maskable, Image.Type type, Transform breakGroud_transform, int childNum)
    {
        Image checkmark = breakGroud_transform.GetChild(childNum).GetComponent<Image>();
        checkmark.sprite = base.checkmark;
        checkmark.color = color;
        checkmark.raycastTarget = rayTarget;
        checkmark.maskable = maskable;
        checkmark.type = type;
    }

    public override void textStyle(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color, int textSize, int childNum)
    {
        Text text = toggle.transform.GetChild(childNum).GetComponent<Text>();

        text.font = font;
        text.fontStyle = fontStyle;
        text.text = message;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;
    }
}