using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_DadItems : PopUpExtras {

    public GameObject clickItems;
    public Image moreInfoBgrd;
    [SerializeField]
    private CloseMoreInfo closeButton;

    public override void Interact()
    {
        GetComponent<Button>().interactable = false;
        moreInfoBgrd.gameObject.SetActive(true);
        closeButton.setPopUpParent(GetComponent<Transform>().gameObject);
        StartCoroutine(moveThroughScript.FadeImage(moreInfoBgrd, moreInfoBgrd.sprite, false, true, false));
        clickItems.gameObject.SetActive(true);
        for (int i = 0; i < clickItems.transform.childCount; i++)
            {
                clickItems.transform.GetChild(i).gameObject.SetActive(true);
            }
            foreach (var item in clickItems.GetComponentsInChildren<Image>())
            {
                item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, false, true, false));
                item.gameObject.GetComponent<ButtonBorder>().doFade = true;
            }
        StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, true, false, false));
    }

    public override void EndInteract()
    {
        GetComponent<Button>().interactable = true;
        foreach (var item in clickItems.GetComponentsInChildren<Image>())
        {
            if (item.IsActive())
            {
                item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, true, false, false));
                item.gameObject.GetComponent<ButtonBorder>().doFade = false;
            }
        }
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        clickItems.gameObject.SetActive(false);
    }
}
