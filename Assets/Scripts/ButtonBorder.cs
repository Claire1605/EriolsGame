using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBorder : MonoBehaviour {

    [HideInInspector]
    public bool doFade = false;
    private bool doOnce = false;

    void Start()
    {
        // StartCoroutine(BorderWaves(GetComponent<Outline>()));
        Debug.Log(GetComponent<Outline>().effectDistance);
    }

    void Update()
    {
        if (doFade && !doOnce)
        {
            StartCoroutine(BorderWaves(GetComponent<Outline>()));
            doOnce = true;
        }
    }

    IEnumerator BorderWaves(Outline o)
    {
        float max = o.effectDistance.y;
        float i = 0;
        while (doFade)
        {
            i += Time.deltaTime * 3;
            o.effectColor = new Color(o.effectColor.r, o.effectColor.g, o.effectColor.b, Mathf.Abs(Mathf.Sin(i)));
            o.effectDistance = new Vector2(Mathf.Abs(Mathf.Sin(i)) * max, Mathf.Abs(Mathf.Sin(i)) * max);
            yield return new WaitForEndOfFrame();
        }
        doOnce = false;
    }
}
