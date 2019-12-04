using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressManager : MonoBehaviour
{

    public GameObject stressBar;
    public float startingWidth;

    public float currentSize;

    public Text barWidth;


    //temporary
    public Button addStress;
    public Button removeStress;

    private void Start()
    {
        var tempSize = stressBar.transform as RectTransform;
        startingWidth = tempSize.rect.width;

        addStress.onClick.AddListener(addStrs);
        removeStress.onClick.AddListener(rStrs);

        updateWidthTxt(startingWidth);

        currentSize = 100;
    }

    void updateWidthTxt(float gibenWidth)
    {
        barWidth.text = "" + gibenWidth;
    }

    void decreaseStress(float percent)
    {
        currentSize = currentSize - percent;

        float widthDelta = (startingWidth / 100) * currentSize;

        var stressBarTransform = stressBar.transform as RectTransform;
        stressBarTransform.sizeDelta = new Vector2(widthDelta, stressBarTransform.sizeDelta.y);

        updateWidthTxt(widthDelta);
    }

    void increaseStress(float percent)
    {
        currentSize = currentSize + percent;

        float widthDelta = (startingWidth / 100) * currentSize;

        var stressBarTransform = stressBar.transform as RectTransform;
        stressBarTransform.sizeDelta = new Vector2(widthDelta, stressBarTransform.sizeDelta.y);

        updateWidthTxt(widthDelta);
    }

    void addStrs()
    {
        increaseStress(10);
    }

    void rStrs()
    {
        decreaseStress(10);
    }
}
