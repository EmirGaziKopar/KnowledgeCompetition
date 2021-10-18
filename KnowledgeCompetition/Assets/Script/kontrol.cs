using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class kontrol : MonoBehaviour
{

    public static bool internet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(netKontrol()); //oyun ilk a��ld���nda bir defa �a��r�ls�n daha sonra kendi oyundan ��k�lana kadar kendini �a��rmaya devam edecektir.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator netKontrol()
    {
        //www.google.com (URL)
        //https://www.google.com/selim.html (URI)

        WWWForm form = new WWWForm();
        //form.AddField("myField", "myData"); Biz bi�ey g�ndermicez sadece internet var m� kontrol ediyoruz

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/bilgi/netkontrol.txt", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                internet = false; //internet yok veya sunucu devre d��� kalm�� yani kopukluk var
            }
            else
            {
                internet = true;
                Debug.Log("Internet baglantisi saglandi");
                
            }
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(netKontrol()); //2 saniyede bir kendini �a��r�p kontrol ger�ekle�tirecek
    }
    
}
