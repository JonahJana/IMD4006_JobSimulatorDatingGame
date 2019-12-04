using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressManager : MonoBehaviour
{
    public GameObject stressBar;

    private float originalWidth;
    private float onePercentSize;

    public float currentSize;
    private float lowestSize;
    private float highestSize;

    public Text barWidth;

    private void Start()
    {
        var tempSize = stressBar.transform as RectTransform;
        originalWidth = tempSize.rect.width;

        lowestSize = 0;
        highestSize = 100;

        onePercentSize = originalWidth / highestSize;

        updateStressSize(0);
    }

    void updateWidthTxt(float givenWidth)
    {
        barWidth.text = "" + givenWidth;
    }


    public void updateStressSize(float percent)
    {
        currentSize = currentSize + percent;

        if(currentSize < 0)
        {
            currentSize = 0;
        }
        if(currentSize > 100)
        {
            // end the interview
            currentSize = 100;
            Debug.Log("way too stressed");
        }

        float newWidth = onePercentSize * currentSize;

        var stressBarTransform = stressBar.transform as RectTransform;
        stressBarTransform.sizeDelta = new Vector2(newWidth, stressBarTransform.sizeDelta.y);

        updateWidthTxt(newWidth);
    }
}
