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
        Application.OpenURL("link");
    }

    IEnumerator pressText(Text text)
    {
        float i = 0;
        float j = 0;
        while (i<1)
        {
            i += Time.deltaTime;
            text.color = Color.Lerp(new Color(0.2f, 0.2f, 0.2f, 1), new Color(0.7f, 0.7f, 0.7f, 1), i);
            yield return new WaitForEndOfFrame();
        }
        while (j < 1)
        {
            j += Time.deltaTime;
            text.color = Color.Lerp(new Color(0.7f, 0.7f, 0.7f, 1), new Color(0.2f, 0.2f, 0.2f, 1), i);
            yield return new WaitForEndOfFrame();
        }
    }
}
