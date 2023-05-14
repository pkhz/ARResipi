using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveMarker : MonoBehaviour
{
    [SerializeField] private Texture2D aKicap;
    [SerializeField] private Texture2D aKunyit;
    [SerializeField] private Texture2D nasGorIkanMasin;

    private GameObject panel;
    //private Text panelText;

    //Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("confirmationmuatturun");
        //panelText = GameObject.FindGameObjectWithTag("confirmtext").GetComponent<Text>();
        panel.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void SaveAyamKicap()
    {
        //if (PlayerPrefs.GetInt("num") != 1)
        //{ 
            NativeGallery.SaveImageToGallery(aKicap, "ARResipi Marker", "MarkerAyamKicap");
            NativeGallery.SaveImageToGallery(aKunyit, "ARResipi Marker", "MarkerAyamKunyit");
            NativeGallery.SaveImageToGallery(nasGorIkanMasin, "ARResipi Marker", "MarkerNasiGorengIkanMasin");

            //PlayerPrefs.SetInt("num", 1);
        //}
        //else
        //{
            //paneltext = "Marker sudah ada di dalam galeri.";
       // }

        panel.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Modal()
    {
        panel.SetActive(false);
    }
}
