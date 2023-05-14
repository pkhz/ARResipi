using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PilihResipi : MonoBehaviour
{
    private int makanNum;
    private string bahanObjectName;

    [SerializeField] private Text bahanName;
    [SerializeField] private Text resipiName;

    // Start is called before the first frame update
    void Start()
    {
        //bahanName = GameObject.Find("Nama Bahan").GetComponent<Text>(); //cant find inactive obj so comment also later maybe delete
        //resipiName = GameObject.Find("Nama Resipi").GetComponent<Text>();
        //bahanName.gameObject.SetActive(false);
        //resipiName = GameObject.FindGameObjectWithTag("Makanan").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.transform.tag != "makanan")
                {
                    //bahanName.gameObject.SetActive(true);
                    bahanName.text = Hit.transform.name;
                }
                //else
                //{
                //resipiName.text = Hit.transform.name;
                //}
                
            }
        }
    }

    public void MakanNum(int num)
    {
        makanNum = num;
    }

    public void SelectRecipe()
    {
        PlayerPrefs.SetInt("choosenRecipeId", makanNum);
        SceneManager.LoadScene("IkutResipi");
    }
}
