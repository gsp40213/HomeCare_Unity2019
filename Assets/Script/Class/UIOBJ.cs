using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class UIOBJ
{
    public abstract class ButtonSetting
    {
        protected Button button;
        protected float pointX, pointY, sizeX, sizeY;
        protected UnityAction onClick;

        public ButtonSetting(Button button, float pointX, float pointY, float sizeX, float sizeY, UnityAction onClick)
        {
            this.button = button;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.onClick = onClick;
        }

        /// <summary>
        /// text_button Function
        /// </summary>
        /// <param font="Font"></param>
        /// <param fontStyle="FontStyle"></param>
        /// <param message="string"></param>
        /// <param textAnchor="TextAnchor"></param>
        /// <param color="Color"></param>
        /// <param textSize="int"></param>
        /// <returns></returns>
        public abstract void textStype(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor,
           Color color, int textSize, int childNum);

        /// <summary>
        /// text_button Function
        /// </summary>
        /// <param font="Font"></param>
        /// <param fontStyle="FontStyle"></param>
        /// <param message="string"></param>
        /// <param textAnchor="TextAnchor"></param>
        /// <param color="Color"></param>
        /// <param textSize="int"></param>
        /// <returns></returns>
        public abstract void image(Sprite image, Color color, bool rayTarget, bool maskable, Image.Type type, int childNum);
    }

    public abstract class Image_Setting
    {
        protected Image image;
        protected float pointX, pointY, sizeX, sizeY;

        public Image_Setting(Image image, float pointX, float pointY, float sizeX, float sizeY)
        {
            this.image = image;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public abstract Image function(Sprite sprite);
        public abstract Image scrollRectImage(Sprite sprite, bool horizontal, bool vertical, RectTransform content);
    }

    public abstract class Text_Setting
    {
        protected Text text;
        protected float pointX, pointY;
        protected float sizeX, sizeY;
        protected string message;
        protected int textSize;

        public Text_Setting(Text text, float pointX, float pointY, float sizeX, float sizeY, string message, int textSize)
        {
            this.text = text;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.message = message;
            this.textSize = textSize;
        }
        /// <summary>
        /// style
        /// </summary>
        /// <param font="Font"></param>
        /// <param fontStyle="FontStyle"></param>
        /// <param textAnchor="TextAnchor"></param>
        /// <param color="Color"></param>
        /// <returns></returns>
        public abstract void style(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color);

        public abstract void messageText(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color, string message);

        /// <summary>
        /// areaText
        /// </summary>
        /// <param anchorsMin="Vector2"></param>
        /// <param anchorsMax="Vector2"></param>
        /// <param pivot="Vector2"></param>
        /// <returns></returns>
        public abstract void areaText(Vector2 anchorsMin, Vector2 anchorsMax, Vector2 pivot);
    }

    public abstract class InputField_Setting
    {
        protected InputField inputField;
        protected float pointX, pointY, sizeX, sizeY;
        protected InputField.ContentType contentType;

        public InputField_Setting(InputField inputField, float pointX, float pointY, float sizeX, float sizeY, InputField.ContentType contentType)
        {
            this.inputField = inputField;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.contentType = contentType;
        }

        public abstract void textStyle(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color, int textSize);
    }

    public abstract class Toggle_Setting
    {
        protected Toggle toggle;
        protected float pointX, pointY;
        protected Sprite breakGroud;
        protected Sprite checkmark;


        public Toggle_Setting(Toggle toggle, Sprite breakGroud, Sprite checkmark, float pointX, float pointY)
        {
            this.toggle = toggle;
            this.breakGroud = breakGroud;
            this.checkmark = checkmark;
            this.pointX = pointX;
            this.pointY = pointY;
        }
        public abstract void breakGroud_ImageType(Color color, bool rayTarget, bool maskable, Image.Type type, int childNum);
        public abstract void checkmark_ImageType(Color color, bool rayTarget, bool maskable, Image.Type type, 
            Transform breakGroud_transform, int childNum);

        public abstract void textStyle(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color, 
            int textSize, int childNum);

    }

    public abstract class Area_Setting
    {
        protected RectTransform areaObj;
        protected Vector2 anchorsMin;
        protected Vector2 anchorsMax;
        protected Vector2 pivot;

        public Area_Setting(RectTransform areaObj, Vector2 anchorsMin, Vector2 anchorsMax, Vector2 pivot)
        {
            this.areaObj = areaObj;
            this.anchorsMin = anchorsMin;
            this.anchorsMax = anchorsMax;
            this.pivot = pivot;
        }

        public abstract RectTransform function(TextAnchor textAnchor, bool controlWidth, bool controlHeight, 
            bool scaleWidth, bool scaleHeight, bool forceExpandWidth, bool forceExpandHeight);

        public abstract RectTransform defaultFunction(Vector2 sizeDelta);
    }
}

public interface OnClick
{
    void onClick();
}

public interface CalculatoOnClck 
{
    void oneClick();
    void twoClick();
    void threeClick();
    void addClick();
    void fourClick();
    void fiveClick();
    void sixClick();
    void reduceClick();   
    void sevenClick();
    void eightClick();
    void nineClick();
    void takeClick();
    void zeroClick();
    void chearClick();
    void equalClick();
    void removeClick();
}