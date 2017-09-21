using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Phone : PopUpExtras {

    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private GameObject phone;
  //  [SerializeField]
  //  private MoveThroughScript moveThroughScript;
    private Vector2 offset = new Vector2(30, 0);

    public override void Interact()
    {
        Cursor.SetCursor(cursor, offset, CursorMode.ForceSoftware);
        phone.SetActive(true);
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        GetComponent<Button>().interactable = false;
        foreach (var item in phone.GetComponentsInChildren<Image>())
        {
            item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, false, true, false));
            item.gameObject.GetComponent<ButtonBorder>().doFade = true;
        }
    }

    public override void EndInteract()
    {
        phone.SetActive(false);
        GetComponent<Image>().color = new Color(0, 0, 0, 1);
        GetComponent<Button>().interactable = true;

        foreach (var item in phone.GetComponentsInChildren<Image>())
        {
            if (item.IsActive())
            {
                item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, true, false, false));
                item.gameObject.GetComponent<ButtonBorder>().doFade = false;
            }
        }
    }
}
