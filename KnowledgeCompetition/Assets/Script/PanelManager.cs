using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public GameObject kayitPanel, anamenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("kayitDurumu")) //Bu anahtar�n Hen�z bir keyi yoksa 
        {
            kayitPanel.SetActive(true);
            anamenuPanel.SetActive(false);
        }
        else
        {//e�er key de�eri var ise kullan�c� kay�t olmus demektir o zaman kay�t panelini false yap�yoruz.
            kayitPanel.SetActive(false);
            anamenuPanel.SetActive(true);
        }

        
    }

    public void devamet()
    {       
        PlayerPrefs.SetInt("kay�tDurumu", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
