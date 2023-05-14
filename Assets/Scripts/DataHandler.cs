using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private GameObject[] bahanChooseRecipe;
    private int choosenRecipe = 0;

    //btn stuff
    [SerializeField] private ButtonManager btnManagerPrefab; //create a game object that holds btnmanager
    [SerializeField] private GameObject btnContainer;
    
    //choosereicpe bahan spawn reference
    //[SerializeField] private GameObject tempatBahan;
    //[SerializeField] private GameObject makanan;

    [SerializeField] private List<Recipe> recipe; //list or
    //[SerializeField] private Recipe[] recipe; //array?

    private int current_id = 1;


    //instance for DataHandler class
    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    private void Start()
    {
        LoadItems();
        //CreateButton();
        BahanSeterusnyaButton.InstanceSeterusnya.stepMakananMax = recipe.Count;
    }

    //load scriptables through resources folder/addresables
    void LoadItems()
    {
        var recipeObj = Resources.LoadAll("ChooseRecipe", typeof(Recipe));
        foreach(var recipeDalamRecipeObj in recipeObj)
        {
            recipe.Add(recipeDalamRecipeObj as Recipe); //add a recipe scriptable into this class recipe scroptables  lsit
        }
    }

    //create each button for each recipe
    //set the button id and image
    void CreateButton()
    {
        //set every recipe to button beacuase want to load all bttons
        foreach (Recipe recipeEach in recipe)
        {
            ButtonManager b = Instantiate(btnManagerPrefab, btnContainer.transform);
            b.BtnId = current_id;
            //b.BtnTexture = recipeEach.recipeImage;
            current_id++;
        }
    }

    /*void SetTempatBahan()
    {
        
    }

    void GetTempatBahan()
    {

    }

    void SetMakanan()
    {

    }

    void GetMakanan()
    {

    }*/

    //set recipe bahan //and makanan or makanan separate get and set? /set id only
    public void SetRecipe(int id) //test set recipe id
    {
        if (id != 0)
            choosenRecipe = id;
        //Debug.Log(choosenRecipe);
    }
    public Recipe GetRecipe(int id) //test get
    {
        if (id != 0)
            return recipe[id-1];
        else
            return null;

    }

    public int GetChoosenNum() //test get
    {
        if (choosenRecipe != 0)
            return choosenRecipe;
        else
            return 0;
        
    }

    //set recipe bahan //and makanan or makanan separate get and set?
    public void SetRecipeBahan(int id)
    {
        //only set the bahan when a button is selected
        foreach(var bahans in recipe[id].bahan)
        {
            //foreach(var bahansChooseRecipe in bahanChooseRecipe)
            //{
                bahanChooseRecipe[id] = bahans; //will this work? //should instatntiate bahan here?
            //}
        }
        
    }

    public GameObject[] GetRecipe2()
    {
        return bahanChooseRecipe;
    }
}
