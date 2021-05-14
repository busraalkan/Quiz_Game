using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text DogruSayisiCevapText, YanlisSayisiAdetText, PuanText;
    [SerializeField]
    private GameObject[] Stars = new GameObject[3];
    public void SonuclariGetir(int dogruAdeti, int yanlisSayisi, int Puan)
    {
        DogruSayisiCevapText.text = dogruAdeti.ToString();
        YanlisSayisiAdetText.text = yanlisSayisi.ToString();
        PuanText.text = Puan.ToString();
    
        foreach (var item in Stars)
        {
            item.SetActive(false);
        }
        if (dogruAdeti == 1)
        {
            Stars[0].SetActive(true);
        }
        else if (dogruAdeti == 2)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
        }
        else if (dogruAdeti == 3)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
            Stars[2].SetActive(true);
        }
    }
}
