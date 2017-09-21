﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveThroughScript : MonoBehaviour {

    private static MoveThroughScript instance = null;
    private MoveThroughScript() { }

    public static MoveThroughScript InputControllerInstance;

    [SerializeField]
    private GameObject interactiveSprites;
    [SerializeField]
    private Text mainText;
    [SerializeField]
    private Image bgrdImage;
    [SerializeField]
    private Image PUImage;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject exitButton;
    [HideInInspector]
    public bool canClickAgain = true;

    void Awake()
    {
        if (InputControllerInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            InputControllerInstance = this;
        }
        else if (InputControllerInstance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mainText.text = StoryManager.Ins.StoryPages[0].PageSections[0].mainScript;
    }

    public void NextClick() //Updates main text and increments current section int
    {
        if (canClickAgain)
        {
            //Fade out any pop-up images
            if (StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage != null)
            {
                StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<PopUpExtras>().EndInteract();
                StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<ButtonBorder>().doFade = false;
                StartCoroutine(FadeImage(StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>(), StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>().sprite, true, false, false));  
            }

            //Switch to next section, same page
            if (StoryManager.Ins.cSection < StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections.Count - 1)
            {
                StoryManager.Ins.cSection += 1;
                StartCoroutine(FadeText()); //Lerp fade text out, update text, then fade in
                //Fade in any new pop-up images
                if (StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage != null)
                {
                    StartCoroutine(FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, true, false, false));
                    StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.SetActive(true);
                    StartCoroutine(FadeImage(StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>(), StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>().sprite, false, true, false));
                    StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<ButtonBorder>().doFade = true;
                }
            }
            //Switch to next page
            else if (StoryManager.Ins.cSection == StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections.Count - 1
                && StoryManager.Ins.cPage < StoryManager.Ins.StoryPages.Count - 1)
            {
                StoryManager.Ins.cSection = 0;
                StoryManager.Ins.cPage += 1;
                StartCoroutine(FadeText());
                StartCoroutine(FadeImage(bgrdImage, StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].pageBackground, true, true, true));
            }
            else if (StoryManager.Ins.cSection == StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections.Count - 1
                && StoryManager.Ins.cPage == StoryManager.Ins.StoryPages.Count - 1)
            {
                exitButton.SetActive(true);
                exitButton.GetComponent<ButtonBorder>().doFade = true;
            }
        }
    }

    IEnumerator FadeText()
    {
        //canClickAgain = false;
        float i = 0;
        float j = 0;
        float alpha = 1;
        while (i<1)
        {
            i += Time.deltaTime * StoryManager.Ins.textFadeSpeed;
            alpha = Mathf.Lerp(1, 0, StoryManager.Ins.textFadeCurve.Evaluate(i));
            mainText.color = new Color(mainText.color.r, mainText.color.g, mainText.color.b, alpha);
            yield return new WaitForEndOfFrame(); 
        }
        mainText.text = StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].mainScript;
        while (j < 1)
        {
            j += Time.deltaTime * StoryManager.Ins.textFadeSpeed;
            alpha = Mathf.Lerp(0, 1, StoryManager.Ins.textFadeCurve.Evaluate(j));
            mainText.color = new Color(mainText.color.r, mainText.color.g, mainText.color.b, alpha);

           // if (j>0.8f)
           //     canClickAgain = true; //able to move forward slightly earlier than end fade

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator FadeImage(Image image, Sprite sprite, bool fadeOut, bool fadeIn, bool bgrd)
    {
        float i = 0;
        float j = 0;
        float alpha = 1;
        if (fadeOut)
        {
            while (i < 1)
            {
                i += Time.deltaTime * StoryManager.Ins.textFadeSpeed;
                alpha = Mathf.Lerp(1, 0, StoryManager.Ins.textFadeCurve.Evaluate(i));
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                yield return new WaitForEndOfFrame();
            }
            if (!bgrd)
                image.gameObject.SetActive(false);
        }
        image.sprite = sprite;
        if (fadeIn)
        {
            while (j < 1)
            {
                j += Time.deltaTime * StoryManager.Ins.textFadeSpeed;
                alpha = Mathf.Lerp(0, 1, StoryManager.Ins.textFadeCurve.Evaluate(j));
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                yield return new WaitForEndOfFrame();
            }
        }
        //canClickAgain = true;
    }

    public IEnumerator FadeOtherText(Text text, bool fadeOut, bool fadeIn)
    {
       // canClickAgain = false;
        float i = 0;
        float j = 0;
        float alpha = 1;
        if (fadeOut)
        {
            while (i < 1)
            {
                i += Time.deltaTime * StoryManager.Ins.textFadeSpeed;
                alpha = Mathf.Lerp(1, 0, StoryManager.Ins.textFadeCurve.Evaluate(i));
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                yield return new WaitForEndOfFrame();
            }
            text.gameObject.SetActive(false);
        }
        if (fadeIn)
        {
            while (j < 1)
            {
                j += Time.deltaTime * StoryManager.Ins.textFadeSpeed;
                alpha = Mathf.Lerp(0, 1, StoryManager.Ins.textFadeCurve.Evaluate(j));
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
              //  if (j > 0.8f)
              //      canClickAgain = true; //able to move forward slightly earlier than end fade
                yield return new WaitForEndOfFrame();
            }
        }
        //canClickAgain = true;
    }
}
