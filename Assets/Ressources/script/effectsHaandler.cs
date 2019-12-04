using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectsHaandler : MonoBehaviour
{
    public GameObject loveEffectImg;

    private void Start()
    {
        Color alphaChanger = loveEffectImg.GetComponent<SpriteRenderer>().material.color;
        alphaChanger.a = 0;

        loveEffectImg.GetComponent<SpriteRenderer>().material.color = alphaChanger;
    }

    public void showLoveEffect()
    {
        Color alphaChanger = loveEffectImg.GetComponent<SpriteRenderer>().material.color;
        alphaChanger.a = 1;

        loveEffectImg.GetComponent<SpriteRenderer>().material.color = alphaChanger;
    }

    public void hideLoveEffect()
    {
        Color alphaChanger = loveEffectImg.GetComponent<SpriteRenderer>().material.color;
        alphaChanger.a = 0;

        loveEffectImg.GetComponent<SpriteRenderer>().material.color = alphaChanger;
    }
}
