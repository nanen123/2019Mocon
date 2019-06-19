using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "wall":
                GameManager.instance.pc.Movable = false;
                GameManager.instance.pc.toVector = transform.parent.position;
                break;

            case "NPC":
                GameManager.instance.npc = other.GetComponent<NPCScript>();
                GameManager.instance.chatButton.SetActive(true);
                break;

            case "Move":
                GameManager.instance.path = other.GetComponent<Path>();
                GameManager.instance.path.moveButton.SetActive(true);
                break;

            case "House":
                House temp = other.GetComponent<House>();
                GameManager.instance.house = temp;
                if (!temp.isIn)
                {
                    GameManager.instance.house.outButton.SetActive(false);
                    GameManager.instance.house.inButton.SetActive(true);
                }
                else if (temp.isIn)
                {
                    GameManager.instance.house.outButton.SetActive(true);
                    GameManager.instance.house.inButton.SetActive(false);
                }
                break;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "NPC":
                GameManager.instance.npc = null;
                GameManager.instance.chatButton.SetActive(false);
                GameManager.instance.script.text = "";
                break;

            case "Move":
                GameManager.instance.path.moveButton.SetActive(false);
                GameManager.instance.path = null;
                break;

            case "House":
                GameManager.instance.house.outButton.SetActive(false);
                GameManager.instance.house.inButton.SetActive(false);
                break;
        }
    }
}
