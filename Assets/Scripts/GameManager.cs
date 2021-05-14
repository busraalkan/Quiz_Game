using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Soru[] SorularDizisi = new Soru[3];
    [SerializeField]
    private Text SoruText, DogruText, YanlisText;
    [SerializeField]
    private GameObject DogruButonu, YanlisButonu, SoruPaneli;

    static List<Soru> CevaplanmamisSorular;
    SonucManager SonucManagerObje;
    Soru GuncelSoru;
    int DogruSayisi, YanlisSayisi = 0;
    int toplamPuan = 0;

    void Start()
    {
        if (CevaplanmamisSorular == null || CevaplanmamisSorular.Count == 0)
        {
            CevaplanmamisSorular = SorularDizisi.ToList<Soru>();
        }
        SoruSec();
    }
    void SoruSec()
    {
        DogruButonu.GetComponent<RectTransform>().DOLocalMoveX(-331, 0.5f);
        YanlisButonu.GetComponent<RectTransform>().DOLocalMoveX(331, 0.5f);
        int RastgeleSoruIndeksi = Random.Range(0, CevaplanmamisSorular.Count);
        GuncelSoru = CevaplanmamisSorular[RastgeleSoruIndeksi];
        CevaplanmamisSorular.Remove(GuncelSoru);
        SoruText.text = GuncelSoru.Sual;
        Cevaplar();
    }
    IEnumerator SoruArasiBekleRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        if (CevaplanmamisSorular.Count <= 0)
        {
            SoruPaneli.SetActive(true);
            SonucManagerObje = Object.FindObjectOfType<SonucManager>();
            SonucManagerObje.SonuclariGetir(DogruSayisi, YanlisSayisi, toplamPuan);
        }
        else
        {
            SoruSec();
        }
    }
    public void DogruButonuCalisma()
    {
        if (GuncelSoru.DogruMu)
        {
            Debug.Log("Dogru yaptın.");
            DogruSayisi++;
            toplamPuan += 100;
        }
        else
        {
            Debug.Log("Yanlis yaptin.");
            YanlisSayisi++;
        }
        Debug.Log("dogru:  " + DogruSayisi + " yanlis:  " + YanlisSayisi);
        YanlisButonu.GetComponent<RectTransform>().DOLocalMoveX(1000f, 1f);
        StartCoroutine(SoruArasiBekleRoutine());
    }
    public void YanlisButonCalisma()
    {
        if (!GuncelSoru.DogruMu)
        {
            Debug.Log("Dogru yaptin.");
            DogruSayisi++;
            toplamPuan += 100;
        }
        else
        {
            Debug.Log("Yanlis yaptin.");
            YanlisSayisi++;
        }
        Debug.Log("dogru:  " + DogruSayisi + " yanlis:  " + YanlisSayisi);
        DogruButonu.GetComponent<RectTransform>().DOLocalMoveX(-1000f, 1f);
        StartCoroutine(SoruArasiBekleRoutine());
    }
    void Cevaplar()
    {
        if (GuncelSoru.DogruMu)
        {
            DogruText.text = "YANLIS CEVAPLADIN!!!";
            YanlisText.text = "DOGRU CEVAPLADIN!!!";

        }
        else if (!GuncelSoru.DogruMu)
        {
            DogruText.text = "DOGRU CEVAPLADIN!!!";
            YanlisText.text = "YANLIS CEVAPLADIN!!!";
        }
    }
}
