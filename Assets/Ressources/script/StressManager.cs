using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressManager : MonoBehaviour
{

    public GameObject stressBar;
    public float startingWidth;


    //temporary
    public Button addStress;
    public Button removeStress;

    private void Start()
    {
        var tempSize = stressBar.transform as RectTransform;
        startingWidth = tempSize.rect.width;

        addStress.onClick.AddListener(addStrs);
        removeStress.onClick.AddListener(rStrs);
    }

    void decreaseStress(float percent)
    {
        float widthDelta = -1 * ((startingWidth / 100) * percent);

        var stressBarTransform = stressBar.transform as RectTransform;
        stressBarTransform.sizeDelta = new Vector2(widthDelta, stressBarTransform.sizeDelta.y);
    }

    void increaseStress(float percent)
    {
        float widthDelta = 1 * ((startingWidth / 100) * percent);

        var stressBarTransform = stressBar.transform as RectTransform;
        stressBarTransform.sizeDelta = new Vector2(widthDelta, stressBarTransform.sizeDelta.y);
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
