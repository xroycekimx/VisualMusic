using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image fadePanel;

    void Start()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (Time.fixedTime > 200)
        {
            fadePanel.color = new Color(0.0f, 0.0f, 0.0f, Mathf.Lerp(fadePanel.color.a, 1.0f, Time.deltaTime));
        }
    }
}
