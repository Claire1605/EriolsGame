using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewindButtons : MonoBehaviour {

    [SerializeField]
    private MoveThroughScript moveThroughScript;
    [SerializeField]
    private StoryManager storyManager;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject closeButton;
    [SerializeField]
    private Image bgrdImage;
    [SerializeField]
    private Image moreInfoBgrd;

    public void RewindOnce()
    {
        FadeOutPopUps();

        GeneralRewindSetup();

        StoryManager.Ins.cSection = 0;
        StartCoroutine(moveThroughScript.FadeText()); //Lerp fade text out, update text, then fade in

        FadeInPopUps();
    }

    public void RewindTwice()
    {
        FadeOutPopUps();

        GeneralRewindSetup();

        StoryManager.Ins.cSection = 0;
        if (storyManager.cPage > 0)
            StoryManager.Ins.cPage -= 1;
        StartCoroutine(moveThroughScript.FadeText());
        StartCoroutine(moveThroughScript.FadeImage(bgrdImage, StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].pageBackground, true, true, true));

        FadeInPopUps();
    }

    void GeneralRewindSetup()
    {
        moveThroughScript.canClickAgain = true;
        moveThroughScript.popUpTextActive = false;

        if (closeButton.activeSelf == true)
        {
            closeButton.GetComponent<CloseMoreInfo>().closePanel();
        }
        PopUp_MoreInfo[] activePopUps = FindObjectsOfType(typeof(PopUp_MoreInfo)) as PopUp_MoreInfo[];
        foreach (var item in activePopUps)
        {
            item.EndInteract();
        }
        StartCoroutine(moveThroughScript.FadeImage(moreInfoBgrd, moreInfoBgrd.sprite, true, false, false));
        nextButton.SetActive(true);
        StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, false, true, false));
    }

    void FadeOutPopUps()
    {
        //Fade out any pop-up images
        if (StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage != null)
        {
            StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<PopUpExtras>().EndInteract();
            StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<ButtonBorder>().doFade = false;
            StartCoroutine(moveThroughScript.FadeImage(StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>(), StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>().sprite, true, false, false));
        }
    }

    void FadeInPopUps()
    {
        //Fade in any new pop-up images
        if (StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage != null)
        {
            StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, true, false, false));
            StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.SetActive(true);
            StartCoroutine(moveThroughScript.FadeImage(StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>(), StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<Image>().sprite, false, true, false));
            StoryManager.Ins.StoryPages[StoryManager.Ins.cPage].PageSections[StoryManager.Ins.cSection].clickableImage.GetComponent<ButtonBorder>().doFade = true;
        }
    }
}
