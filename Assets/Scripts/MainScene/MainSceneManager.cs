using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public enum mainState
    {
        yet,
        first,
        second
    };

    public GameObject title;
    public Image startBtn;
    public Image quitBtn;
    public Color color;
    private RectTransform tr;
    mainState state = mainState.yet;

    public void Start()
    {
        StartCoroutine("StartGame");
    }

    public void Update()
    {
        switch(state)
        {
            case mainState.first:
                title.GetComponent<RectTransform>().transform.Translate(Vector3.up * Time.deltaTime * 40);
                break;
            case mainState.second:
                StartCoroutine("FadeOut");
                break;
        }
    }

    IEnumerator FadeOut()
    {
        while (color.a < 1f)
        {
            color.a += 0.01f;
            startBtn.color = color;
            quitBtn.color = color;
            yield return new WaitForSeconds(0.06f);
        }
    }

    public IEnumerator StartGame()
    {
        state = mainState.first;
        yield return new WaitForSeconds(1.3f);
        state = mainState.second;
    }

}
