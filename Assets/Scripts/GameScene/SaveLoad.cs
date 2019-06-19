using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("PX", //player.transform.position.x
            11.25f);
        PlayerPrefs.SetFloat("PY", //player.transform.position.y
            -6.5f);
        PlayerPrefs.SetFloat("PZ", //player.transform.position.z
            -9f);
    }

    public void Load()
    {
        Vector3 playerpos = new Vector3(PlayerPrefs.GetFloat("PX"), PlayerPrefs.GetFloat("PY"), PlayerPrefs.GetFloat("PZ"));
        player.transform.position = playerpos;
    }
}
