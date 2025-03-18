using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComicCutscene : MonoBehaviour
{
    public Image[] panels; // Assign panels via Inspector
    public float fadeDuration = 1f;
    public float displayTime = 3f;

    private int currentPanel = 0;
    private bool isSkipping = false;

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    public void SkipCutscene()
    {
        isSkipping = true;
        SceneManager.LoadScene("NextScene"); // Replace with your next scene name
    }

    IEnumerator PlayCutscene()
    {
        foreach (var panel in panels)
        {
            panel.color = new Color(1, 1, 1, 0); // Set transparent
        }

        while (currentPanel < panels.Length && !isSkipping)
        {
            yield return StartCoroutine(FadeIn(panels[currentPanel]));
            yield return new WaitForSeconds(displayTime);
            yield return StartCoroutine(FadeOut(panels[currentPanel]));
            currentPanel++;
        }

        if (!isSkipping)
        {
            // Load the next scene after cutscene finishes
            SceneManager.LoadScene("NextScene"); // Replace with your next scene name
        }
    }

    IEnumerator FadeIn(Image panel)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            panel.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(Image panel)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            panel.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }
}
