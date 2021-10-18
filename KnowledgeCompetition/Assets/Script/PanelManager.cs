using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public GameObject kayitPanel, anamenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("kayitDurumu")) //Bu anahtarýn Henüz bir keyi yoksa 
        {
            kayitPanel.SetActive(true);
            anamenuPanel.SetActive(false);
        }
        else
        {//eðer key deðeri var ise kullanýcý kayýt olmus demektir o zaman kayýt panelini false yapýyoruz.
            kayitPanel.SetActive(false);
            anamenuPanel.SetActive(true);
        }

        
    }

    public void devamet()
    {       
        PlayerPrefs.SetInt("kayýtDurumu", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
