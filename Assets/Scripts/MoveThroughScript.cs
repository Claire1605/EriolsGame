using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveThroughScript : MonoBehaviour {

    private static MoveThroughScript instance = null;
    private MoveThroughScript() { }

    public static MoveThroughScript InputControllerInstance;

    [SerializeField]
    private Text mainText;
    [SerializeField]
    private Image bgrdImage;
    [SerializeField]
    private Image PUImage;

    private bool canClickAgain = true;

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
                StartCoroutine(FadeImage(StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>(), StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>().sprite, true, false));
                StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<ButtonBorder>().doFade = false; //Fading button outline
            }

            //Switch to next section, same page
            if (StoryManager.Ins.cSection < StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections.Count - 1)
            {
                StoryManager.Ins.cSection += 1;
                StartCoroutine(FadeText()); //Lerp fade text out, update text, then fade in
                //Fade in any new pop-up images
                if (StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage !=null)
                {
                    StartCoroutine(FadeImage(StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>(), StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>().sprite, false, true));
                    StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<ButtonBorder>().doFade = true; //Fading button outline
                }
            }
            //Switch to next page
            else if (StoryManager.Ins.cSection == StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections.Count - 1
                && StoryManager.Ins.cPage < StoryManager.Ins.StoryPages.Count - 1)
            {
                StoryManager.Ins.cSection = 0;
                StoryManager.Ins.cPage += 1;
                StartCoroutine(FadeText());
                StartCoroutine(FadeImage(bgrdImage, StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].pageBackground, true, true));
            }
        }
    }

    IEnumerator FadeText()
    {
        canClickAgain = false;
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

            if (j>0.8f)
                canClickAgain = true; //able to move forward slightly earlier than end fade

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeImage(Image image, Sprite sprite, bool fadeOut, bool fadeIn)
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
    }
}
