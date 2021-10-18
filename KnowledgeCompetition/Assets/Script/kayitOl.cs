using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


public class kayitOl : MonoBehaviour
{

    public TMP_InputField kullaniciAd;
    public TextMeshProUGUI bilgi;
    public GameObject devam_B;


    // Start is called before the first frame update
    void Start()
    {
        devam_B.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void kontroll()
    {
        if(kontrol.internet == true)
        {
            if (!kullaniciAd.text.Equals("")) //BOS DEGÝLSE
            {
                StartCoroutine(kayit());
                
            }
            else
            {                
                textYazdir("Boþ býrakmayýn !");
            }
        }
        else
        {
            textYazdir("internet baglantisi saglanmadi");
        }
        
    }

    IEnumerator kayit()
    {
        //www.google.com (URL)
        //https://www.google.com/selim.html (URI)

        WWWForm form = new WWWForm();

        form.AddField("unity", "kayitol"); //php'deki dinleyiciler buradan gelecek olan deðerleri dinleyecekler
        form.AddField("kullaniciAdi",kullaniciAd.text);
        //form.AddField("myField", "myData"); Biz biþey göndermicez sadece internet var mý kontrol ediyoruz

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/bilgi/veritabani_islemler.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {                
                textYazdir(www.downloadHandler.text);
                Debug.Log("Internet baglantisi saglandi");
                if (www.downloadHandler.text.Equals("kaydiniz basarili"))
                {
                    devam_B.SetActive(true); //eðer kayýt baþarýlý olduysa devam buttonu açýlacak
                    kullaniciAd.interactable = false;
                }
            }
        }
    }

    void textYazdir(string mesaj)
    {
        bilgi.text = mesaj;
        Invoke("sifirla",1.2f); //bellirli bir süre sonra bana bu fonksiyonu getir demektir 2.parametre time'ý simgeler
    }

    void sifirla()
    {
        bilgi.text = "";
    }
}
