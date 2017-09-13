using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAlphas : MonoBehaviour {

	void Start () {
        foreach (var item in GetComponentsInChildren<Image>())
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, 0);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
	}

}
