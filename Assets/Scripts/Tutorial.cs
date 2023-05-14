using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image ss1;
    [SerializeField] private Image ss2;
    [SerializeField] private Image ss3;
    [SerializeField] private Image ss4;

    private Button btnNext;
    private Button btnPrev;
    private Image imageHolder;
    private Text textHolder;

    private int stepIncrease = 1;
    private int stepIncreaseFirst;
    private int stepIncreaseMax = 4;
    // Start is called before the first frame update
    void Start()
    {
        btnNext = GameObject.FindGameObjectWithTag("bahanNext").GetComponent<Button>();
        btnPrev = GameObject.FindGameObjectWithTag("bahanPrev").GetComponent<Button>();
        btnPrev.gameObject.SetActive(false); //initially no previous

        imageHolder = GameObject.FindGameObjectWithTag("tutoimage").GetComponent<Image>();
        imageHolder.sprite = ss1.sprite;

        textHolder = GameObject.FindGameObjectWithTag("tutotext").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stepTutorial(string operation)
    {
        if (operation == "plus")
        {
            if (stepIncrease < stepIncreaseMax)
            {
                stepIncrease++;

            }

        }

        if (operation == "minus")
        {
            stepIncreaseFirst = 1;

            if (stepIncrease > stepIncreaseFirst)
            {
                stepIncrease--;

            }

        }

        if (stepIncrease == 1)
        {
            //btnPrev.interactable = false;
            //btnNext.interactable = true;
            imageHolder.sprite = ss1.sprite;
            textHolder.text = "1. Letak marker resipi di depan kamera. Marker resipi boleh di muat turun pada bahagian Marker Resipi di menu.";
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(false);

        }
        else if (stepIncrease == 2)
        {
            imageHolder.sprite = ss2.sprite;
            textHolder.text = "2. Setelah marker resipi pilihan diletakkan, objek 3D resipi akan dipaparkan. Objek 3D di tengah ialah makanan. Selainnya ialah bahan yang diperlukan. Sila sentuh objek bahan untuk mengetahui nama bahan. Kemudian, tekan butang hijau untuk ke bahagian seterusnya.";
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(true);
        }
        else if (stepIncrease == 3)
        {
            imageHolder.sprite = ss3.sprite;
            textHolder.text = "3. Letakkan periuk atau ceper di hadapan kamera. Pastikan handle periuk di sebelah kanan. Buka lampu atau betulkan kamera ke arah periuk sekiranya tidak dapat dikesan.";
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(true);
        }
        else if (stepIncrease == stepIncreaseMax)
        {
            //btnPrev.interactable = true;
            //btnNext.interactable = false;
            imageHolder.sprite = ss4.sprite;
            textHolder.text = "4. Setelah periuk dapat dikesan, teks, objek 3D dan video akan dipaparkan. Video dapat di Play/Pause menggunakan butang hijau. Ketiga-tiga objek dapat di rotate, dan zoom. Setelah langkah pertama resipi selesai boleh tekan butang seterusnya untuk langkah resipi seterusnya sehingga habis resipi dan makanan dihidangkan.";
            btnNext.gameObject.SetActive(false);
            btnPrev.gameObject.SetActive(true);
        }
        //else
        //{
        // btnPrev.interactable = true;
        //btnNext.interactable = true;
        //btnNext.gameObject.SetActive(true);
        //btnPrev.gameObject.SetActive(true);
        //}

    }
}
