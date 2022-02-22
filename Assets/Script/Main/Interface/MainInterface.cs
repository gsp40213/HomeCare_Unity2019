using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface
{
    private Image buttonArea;
    private RectTransform area;

    ImageSetting buttonAreaSetting;
    AreaSetting areaSetting;

    public MainInterface(Image buttonArea, RectTransform area)
    {
        this.buttonArea = buttonArea;
        this.area = area;
    }

    public void buttonArea_Layout()
    {
        buttonAreaSetting = new ImageSetting(buttonArea, 1f, 1f, 1.6f, 1.6f);
        buttonAreaSetting.function(null, false, true, area);

        // buttonArea 物件底下子物件
        area.transform.parent = buttonArea.transform;

        areaSetting = new AreaSetting(area, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0.5f, 0.5f));
        areaSetting.function(TextAnchor.MiddleCenter, false, false, false, false, true, true);
    }
}