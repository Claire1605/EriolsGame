using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hyperlink : MonoBehaviour {

    [SerializeField]
    private string link;

	public void GoToLink()
    {
        StartCoroutine(pressText(GetComponentInChildren<Text>()));
        //Application.OpenURL(link);
    }

    IEnumerator pressText(Text text)
    {
        float i = 0;
        while (i<1)
        {
            i += Time.deltaTime * 6;
            text.color = Color.Lerp(new Color(0.2f, 0.2f, 0.2f, 1), new Color(0.9f, 0.9f, 0.9f, 1), i);
            yield return new WaitForEndOfFrame();
        }
        float j = 0;
        while (j < 1)
        {
            j += Time.deltaTime * 6;
            text.color = Color.Lerp(new Color(0.9f, 0.9f, 0.9f, 1), new Color(0.2f, 0.2f, 0.2f, 1), j);
            yield return new WaitForEndOfFrame();
        }
    }
}
