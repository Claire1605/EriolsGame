using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour {

    public static StoryManager Ins;

    void Awake()
    {
        if (Ins == null)
        {
            DontDestroyOnLoad(gameObject);
            Ins = this;
        }
        else if (Ins != this)
        {
            Destroy(gameObject);
        }
    }

    public int cPage = 0;
    public int cSection = 0;
    public float textFadeSpeed = 1;
    public AnimationCurve textFadeCurve;

    [Serializable]
    public class Script
    {
        public string mainScript;
        public GameObject clickableImage;
    }
    [Serializable]
    public class Page
    {
        public string pageTitle;
        public Sprite pageBackground;
        public List<Script> PageSections = new List<Script>();
    }
    public List<Page> StoryPages = new List<Page>();
}
