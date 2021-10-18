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
        StartCoroutine(netKontrol()); //oyun ilk açýldýðýnda bir defa çaðýrýlsýn daha sonra kendi oyundan çýkýlana kadar kendini çaðýrmaya devam edecektir.
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
        //form.AddField("myField", "myData"); Biz biþey göndermicez sadece internet var mý kontrol ediyoruz

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/bilgi/netkontrol.txt", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                internet = false; //internet yok veya sunucu devre dýþý kalmýþ yani kopukluk var
            }
            else
            {
                internet = true;
                Debug.Log("Internet baglantisi saglandi");
                
            }
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(netKontrol()); //2 saniyede bir kendini çaðýrýp kontrol gerçekleþtirecek
    }
    
}
