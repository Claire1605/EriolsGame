using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_9Button : PopUpExtras {

    [SerializeField]
    public GameObject callButton;
    [SerializeField]
    private Image press;
    [SerializeField]
    private Image phone;
    [SerializeField]
    private Sprite phone1;
    [SerializeField]
    private Sprite phone2;
    [SerializeField]
    private Sprite phone3;
    private int counter = 0;

    public override void Interact()
    {
        counter += 1;
        if (counter == 1)
        {
            StartCoroutine(pressIcon());
            phone.sprite = phone1;
        }
        else if (counter == 2)
        {
            StartCoroutine(pressIcon());
            phone.sprite = phone2;
        }
        else if (counter == 3)
        {
            StartCoroutine(pressIcon());
            phone.sprite = phone3;
            callButton.GetComponent<ButtonBorder>().doFade = true;
            callButton.GetComponent<Button>().interactable = true;
        }
        //only press call button after 3rd 9
    }

    public override void EndInteract()
    {
        base.EndInteract();
    }

    IEnumerator  pressIcon()
    {
        press.gameObject.SetActive(true);
        press.transform.position = gameObject.transform.position;
        float i = 0;
        while (i<3)
        {
            i += Time.deltaTime * 20;
            press.color = new Color(press.color.r, press.color.g, press.color.b, Mathf.Abs(Mathf.Sin(i)));
            yield return new WaitForEndOfFrame();
        }
        press.gameObject.SetActive(false);
    }
}
