using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaSetting : UIOBJ.Area_Setting
{

    public AreaSetting(RectTransform areaObj, Vector2 anchorsMin, Vector2 anchorsMax, Vector2 pivot):
        base(areaObj, anchorsMin, anchorsMax, pivot) 
    {

        // Area area setting
        areaObj.anchorMin = anchorsMin;
        areaObj.anchorMax = anchorsMax;
        areaObj.pivot = pivot;

        // Area layout setting
        areaObj.transform.localPosition = Vector2.zero;
        areaObj.right = Vector2.zero;
    }

    // padding four directions
    public int paddingLeft = 0;
    public int paddingRight = 0;
    public int paddingTop = 0;
    public int paddingBottom = 0;

    public float spacing = 10;

    // padding four directions
    public ContentSizeFitter.FitMode horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
    public ContentSizeFitter.FitMode verticalFit = ContentSizeFitter.FitMode.PreferredSize;


    public override RectTransform function(TextAnchor textAnchor, bool controlWidth, bool controlHeight, 
        bool scaleWidth, bool scaleHeight, bool forceExpandWidth, bool forceExpandHeight)
    {
        contentSize(horizontalFit, verticalFit);

        verticalLayoutGroup(textAnchor, controlWidth, controlHeight, scaleWidth, scaleHeight, forceExpandWidth,
            forceExpandHeight);


        return areaObj;
    }

    private ContentSizeFitter contentSize(ContentSizeFitter.FitMode horizontalFit, ContentSizeFitter.FitMode verticalFit)
    {
        ContentSizeFitter contentSizeFitter = areaObj.gameObject.AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = horizontalFit;
        contentSizeFitter.verticalFit = verticalFit;

        return contentSizeFitter;
    }

    private VerticalLayoutGroup verticalLayoutGroup(TextAnchor textAnchor, bool controlWidth, bool controlHeight,
        bool scaleWidth, bool scaleHeight, bool forceExpandWidth, bool forceExpandHeight)
    {
        VerticalLayoutGroup verticalLayoutGroup = areaObj.gameObject.AddComponent<VerticalLayoutGroup>();

        verticalLayoutGroup.childAlignment = textAnchor;

        verticalLayoutGroup.childControlWidth = controlWidth;
        verticalLayoutGroup.childControlHeight = controlHeight;

        verticalLayoutGroup.childScaleWidth = scaleWidth;
        verticalLayoutGroup.childScaleHeight = scaleHeight;

        verticalLayoutGroup.childForceExpandWidth = forceExpandWidth;
        verticalLayoutGroup.childForceExpandHeight = forceExpandHeight;

        verticalLayoutGroup.spacing = spacing;

        verticalLayoutGroup.padding.left = paddingLeft;
        verticalLayoutGroup.padding.right = paddingRight;
        verticalLayoutGroup.padding.top = paddingTop;
        verticalLayoutGroup.padding.bottom = paddingBottom;

        return verticalLayoutGroup;
    }

    public override RectTransform defaultFunction(Vector2 sizeDelta)
    {   
        areaObj.sizeDelta = sizeDelta;

        return areaObj;
    }
}
