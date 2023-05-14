using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BahanSeterusnyaButton : MonoBehaviour
{
    //public Recipe recipe; //temp //buang public
    Recipe recipe;

    Text recipeName;
    Text textBahan;
    GameObject makananObject;
    GameObject bahanObject;
    Button btnNext;
    Button btnPrev;
    Button btnMakananNext;
    Button btnMakananPrev;

    //choosereicpe bahan spawn reference
    [SerializeField] private GameObject tempatBahan;
    [SerializeField] private GameObject makanan;

    //public GameObject makanan;
    //public GameObject tempatBahan;

    int stepIncrease = 1; //start from step1
    int stepIncreaseMakanan = 1;

    int stepBahanFirst;
    int stepMakananFirst;//recipe step 1 constant

    int stepBahanMax; //max step for bahan eg if bahan ends at step 3, set as 3
    public int stepMakananMax;

    int num = 0; //instantiate to 1
    int idChangeFlag; //instantiate to 1

    private static BahanSeterusnyaButton instanceSeterusnya; //delete later sbb x guna ButtonManager which cal this class?
    public static BahanSeterusnyaButton InstanceSeterusnya
    {
        get
        {
            if (instanceSeterusnya == null)
            {
                instanceSeterusnya = FindObjectOfType<BahanSeterusnyaButton>();
            }
            return instanceSeterusnya;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // if (DataHandler.Instance.GetRecipe() != null)
        //{
        //recipe = DataHandler.Instance.GetRecipe(); //test if needed to put in update() //temp comment actually neede
        //}
        //else
        //recipe = Resources.Load<Recipe>("ChooseRecipe/Recipe1");

        //add if null as baove?
        //there is 4 stuff to change/spawn in pilih resipi 
        btnNext = GameObject.FindGameObjectWithTag("bahanNext").GetComponent<Button>();
        btnPrev = GameObject.FindGameObjectWithTag("bahanPrev").GetComponent<Button>();
        btnPrev.gameObject.SetActive(false); //initially no previous

        btnMakananNext = GameObject.FindGameObjectWithTag("bahanMakananNext").GetComponent<Button>();
        btnMakananPrev = GameObject.FindGameObjectWithTag("bahanMakananPrev").GetComponent<Button>();
        btnMakananPrev.gameObject.SetActive(false); //initially no previous

        //btnPrev.interactable = false; //this or setactive?
        //Debug.Log(stepMakananMax);

        //int checkNum = PlayerPrefs.GetInt("choosenRecipeId");

        //if (checkNum != 0) //todo, check if has choosenRecipeID means that if back from IkutResipi should load that reicpe first
            //fillPanel(checkNum);
        //else
        fillPanel(1);
    }

    public void fillPanel(int btnId)
    {
        if (btnId == num)
            idChangeFlag = 0; //0 = not changed
        else
            idChangeFlag = 1;

        //refresh makanan and bahan seterusnya button when click on btnMakananPrev and Next
        if (idChangeFlag != 0)
        {
            stepIncrease = 1;
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(false);

            //Debug.Log(stepIncreaseMakanan);

            if (bahanObject != null)
                Destroy(bahanObject);

            if (makananObject != null)
                Destroy(makananObject);

            if (num != 0)
            {
                recipe = DataHandler.Instance.GetRecipe(btnId); //test if needed to put in update() //temp comment actually needed
            }
            else
                recipe = Resources.Load<Recipe>("ChooseRecipe/Recipe1");

            recipeName = GameObject.FindGameObjectWithTag("namaresipi").GetComponent<Text>();
            textBahan = GameObject.FindGameObjectWithTag("namabahan").GetComponent<Text>(); //perlu ke sebenarnya? perlu kot
            makananObject = GameObject.FindGameObjectWithTag("makananinpilihpanel");
            bahanObject = GameObject.FindGameObjectWithTag("bahaninpilihpanel");

            recipeName.text = recipe.recipeName;
            //textBahan.text = recipe.bahanName[0];
            //makananObject = Instantiate(recipe.makanan, makanan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("tempatmakananbahan").transform);
            //bahanObject = Instantiate(recipe.bahan[0], tempatBahan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("tempatmakananbahan").transform);
            makananObject = Instantiate(recipe.makanan, makanan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("imagetarget").transform);
            bahanObject = Instantiate(recipe.bahan[0], tempatBahan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("imagetarget").transform);
            stepBahanMax = recipe.bahan.Length;

            makananObject.transform.localScale = makanan.transform.localScale;
            bahanObject.transform.localScale = tempatBahan.transform.localScale;

            tempatBahan.SetActive(false);
            makanan.SetActive(false);

            num = btnId;
            
        }

    }

    public void bahanStepCounter(string operation)
    {
        //Debug.Log(stepIncrease);
        Destroy(bahanObject); //destroy prev bahan
        //bahan1.SetActive(true);


        if (operation == "plus")
        {
            if (stepIncrease < stepBahanMax)
            {
                stepIncrease++;
               
            }
            
        }

        if (operation == "minus")
        {
            stepBahanFirst = 1;

            if (stepIncrease > stepBahanFirst)
            {
                stepIncrease--;
               
            }
            
        }

        if (stepIncrease == 1) 
        {
            //btnPrev.interactable = false;
            //btnNext.interactable = true;
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(false);

        }
        else if (stepIncrease == stepBahanMax)
        {
            //btnPrev.interactable = true;
            //btnNext.interactable = false;
            btnNext.gameObject.SetActive(false);
            btnPrev.gameObject.SetActive(true);
        }
        else
        {
            // btnPrev.interactable = true;
            //btnNext.interactable = true;
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(true);
        }

        //textBahan.text = recipe.bahanName[stepIncrease -1];
        bahanObject = Instantiate(recipe.bahan[stepIncrease - 1], tempatBahan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("tempatmakananbahan").transform);

        makananObject.transform.localScale = makanan.transform.localScale;
        bahanObject.transform.localScale = tempatBahan.transform.localScale;
    }

    public void makananStepCounter(string operation)
    {
        if (operation == "plus")
        {
            if (stepIncreaseMakanan < stepBahanMax)
            {
                stepIncreaseMakanan++;

            }

        }

        if (operation == "minus")
        {
            stepBahanFirst = 1;

            if (stepIncreaseMakanan > stepMakananFirst)
            {
                stepIncreaseMakanan--;

            }

        }

        if (stepIncreaseMakanan == 1) //do this for SeterusnyaBUtton too?
        {
            //btnMakananPrev.interactable = false;
            //btnNext.interactable = true;
            btnMakananNext.gameObject.SetActive(true);
            btnMakananPrev.gameObject.SetActive(false);

        }
        else if (stepIncreaseMakanan == stepMakananMax)
        {
            //btnMakananPrev.interactable = true;
            //btnMakananNext.interactable = false;
            btnMakananNext.gameObject.SetActive(false);
            btnMakananPrev.gameObject.SetActive(true);
        }
        else
        {
            // btnMakananPrev.interactable = true;
            //btnMakananNext.interactable = true;
            btnMakananNext.gameObject.SetActive(true);
            btnMakananPrev.gameObject.SetActive(true);
        }
        
        fillPanel(stepIncreaseMakanan);

    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChooseRecipeBtn()
    {
        PlayerPrefs.SetInt("choosenRecipeId", stepIncreaseMakanan);
        SceneManager.LoadScene("IkutResipi");
    }

    // Update is called once per frame
    //void Update()
    //{
    //int choosenNum = DataHandler.Instance.GetChoosenNum();
    //if (choosenNum != recipe.num && choosenNum != 0)
    //{
    //fillPanel(); //test if needed to put in update() //temp comment actually neede
    //}
    //else
    //recipe = Resources.Load<Recipe>("ChooseRecipe/Recipe1");

    //}


}
