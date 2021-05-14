using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Soru
{
    public string Sual;
    public bool DogruMu;
}


//[SerializeField]
//private Soru[] SorularDizisi = new Soru[3];

//private static List<Soru> CevaplanmamisSorular;

//Soru SuAnkiSoru;
//void Start()
//{
//    if (CevaplanmamisSorular == null || CevaplanmamisSorular.Count == 0)
//    {
//        CevaplanmamisSorular = SorularDizisi.ToList<Soru>();
//    }
//    RastgeleSoruSec();
//    Debug.Log("Soru: " + SuAnkiSoru.Sorular + "  Cevap:  " + SuAnkiSoru.DogruMu);
//}
//void RastgeleSoruSec()
//{
//    int RastgeleSoruİndeksi = Random.Range(0, CevaplanmamisSorular.Count);
//    SuAnkiSoru = CevaplanmamisSorular[RastgeleSoruİndeksi];
//}