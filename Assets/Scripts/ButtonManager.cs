using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MoveButton()
    {
        StartCoroutine("MoveButtonClick");
    }

    public void ChatButton()
    {
        StopCoroutine("Chat");
        StartCoroutine("Chat");
    }

    public void MenuButton()
    {
        if (!GameManager.instance.isMenu)
        {
            GameManager.instance.isMenu = true;
            for (int i = 0; i < 3; i++)
            {
                GameManager.instance.statusBtn[i].SetActive(true);
            }
            GameManager.instance.statusUI[0].SetActive(true);
        }
    }

    public void ExitMenu()
    {
        for (int i = 0; i < 3; i++)
        {
            GameManager.instance.statusBtn[i].SetActive(false);
            GameManager.instance.statusUI[i].SetActive(false);
        }
    }

    public void CharacterButton()
    {
        if (GameManager.instance.statusUI[1].activeSelf && !GameManager.instance.statusUI[0].activeSelf)
            GameManager.instance.statusUI[1].SetActive(false);
        else
            GameManager.instance.statusUI[2].SetActive(false);
        GameManager.instance.statusUI[0].SetActive(true);
    }
    public void ItemButton()
    {
        if (GameManager.instance.statusUI[0].activeSelf && !GameManager.instance.statusUI[1].activeSelf)
            GameManager.instance.statusUI[0].SetActive(false);
        else
            GameManager.instance.statusUI[2].SetActive(false);
        GameManager.instance.statusUI[1].SetActive(true);
    }
    public void KeyButton()
    {
        if (GameManager.instance.statusUI[0].activeSelf && !GameManager.instance.statusUI[2].activeSelf)
            GameManager.instance.statusUI[0].SetActive(false);
        else
            GameManager.instance.statusUI[1].SetActive(false);
        GameManager.instance.statusUI[2].SetActive(true);
    }

    public void InHouseButton()
    {
        GameManager.instance.house.isIn = true;
        GameManager.instance.pc.minX = GameManager.instance.house.min;
        GameManager.instance.pc.maxX = GameManager.instance.house.max;
        GameManager.instance.house.GetComponent<SpriteRenderer>().color = GameManager.black;
        GameManager.instance.house.inner.SetActive(true);
    }

    public void OutHouseButton()
    {
        GameManager.instance.house.isIn = false;
        GameManager.instance.house.inner.SetActive(false);
        GameManager.instance.house.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        GameManager.instance.house = null;
        GameManager.instance.pc.SetMinMax();
    }

    public void ScholarInButton()
    {
        if (GameManager.instance.itemList[0])
        {
            StartCoroutine("Chat");
            GameManager.instance.house.isIn = true;
            GameManager.instance.pc.minX = GameManager.instance.house.min;
            GameManager.instance.pc.maxX = GameManager.instance.house.max;
            GameManager.instance.house.GetComponent<SpriteRenderer>().color = GameManager.black;
            GameManager.instance.house.inner.SetActive(true);
        }
        else
        {
            GameManager.instance.script.text = "굳게 닫혀있는 다락문이다.";
        }
    }

    public void ScholarOutButton()
    {
        House temp = GameObject.Find("Scholar").GetComponent<House>();
        GameManager.instance.house.isIn = false;
        GameManager.instance.house.inner.SetActive(false);
        GameManager.instance.house.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        GameManager.instance.house = null;
        GameManager.instance.pc.minX = temp.min;
        GameManager.instance.pc.maxX = temp.max;
    }

    public IEnumerator MoveButtonClick()
    {
        GameManager.instance.pc.Movedir = GameManager.instance.path.dir;
        GameManager.instance.pc.loc = GameManager.instance.path.pathloc;
        GameManager.instance.pc.playerState = STATE.moving;
        yield return new WaitForSeconds(1.8f);
        GameManager.instance.pc.Movedir = Vector2.zero;
        GameManager.instance.pc.playerState = STATE.idle;
        GameManager.instance.pc.SetMinMax();

        switch (GameManager.instance.pc.loc)
        {
            case Plocation.bottom:
                GameManager.instance.p.transform.position = new Vector3(GameManager.instance.p.transform.position.x, -6.5f, -9.0f);
                break;

            case Plocation.middle:
                GameManager.instance.p.transform.position = new Vector3(GameManager.instance.p.transform.position.x, 1.5f, -2.1f);
                break;

            case Plocation.left:
                GameManager.instance.p.transform.position = new Vector3(GameManager.instance.p.transform.position.x, 6.5f, GameManager.instance.p.transform.position.z);

                break;

            case Plocation.right:
                GameManager.instance.p.transform.position = new Vector3(GameManager.instance.p.transform.position.x, 6.5f, GameManager.instance.p.transform.position.z);

                break;

            case Plocation.top:
                GameManager.instance.p.transform.position = new Vector3(GameManager.instance.p.transform.position.x, 11.5f, GameManager.instance.p.transform.position.z);

                break;

        }
    }

    public IEnumerator Chat()
    {
        int length = GameManager.instance.npc.scripts.Length;
        for (int i = 0; i < length; i++)
        {
            GameManager.instance.script.text = GameManager.instance.npc.scripts[i];
            yield return new WaitForSeconds(1.5f);
        }
        GameManager.instance.script.text = null;
    }
}
