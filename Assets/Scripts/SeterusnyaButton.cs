using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;
using UnityEngine.SceneManagement;
public class SeterusnyaButton : MonoBehaviour
{
    private GameObject bahan;

    private Text tgameobject;
    private Button btnNext;
    private Button btnPrev;

    private List<Recipe> recipe = new List<Recipe>();

    public GameObject bahan1;
    public Sprite startSprite;
    public Sprite stopSprite;
    
    private Button buttonVid;
    private VideoPlayer videoPlayer; //video player
    
    //int flagFromChooseRecipe = 1; //temp, actually took value pass from prev scene
    int flagFromChooseRecipe; //todo:test this

    int stepIncrease = 1; //start from step1
    int stepRecipeFirst;
    int stepRecipeMax;

    // Start is called before the first frame update
    void Start()
    {
        flagFromChooseRecipe = PlayerPrefs.GetInt("choosenRecipeId");

        LoadItems();

        tgameobject = GameObject.FindGameObjectWithTag("step1").GetComponent<Text>();
        bahan = GameObject.FindGameObjectWithTag("bahan");

        buttonVid = GameObject.FindGameObjectWithTag("playpause").GetComponent<Button>();
        videoPlayer = GameObject.FindGameObjectWithTag("videoplane").GetComponent<VideoPlayer>();

        btnNext = GameObject.FindGameObjectWithTag("bahanNext").GetComponent<Button>();
        btnPrev = GameObject.FindGameObjectWithTag("bahanPrev").GetComponent<Button>();
        btnPrev.gameObject.SetActive(false); //initially no previous

        //at anoher class maybe ButtonManger call this insctance and pass id
        //create instance here for this class

        /*foreach (var obj in recipe1)
        {
            //instantiate with first index of array as step 1 is first index
            if (obj.num == flagFromChooseRecipe)
            {
                //set recipeChoosen = 
                tgameobject.text = obj.steps[0];
                bahan = Instantiate(obj.bahan[0],bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
                videoPlayer.clip = obj.videos[0];
                //tools? ie imaget arget? ie flagTools(int)
                stepRecipeMax = obj.steps.Length;
            }
        }*/

        //instantiate with first index of array as step 1 is first index
        tgameobject.text = recipe[flagFromChooseRecipe - 1].steps[0];
        tgameobject.text = recipe[flagFromChooseRecipe - 1].steps[0];
        bahan = Instantiate(recipe[flagFromChooseRecipe - 1].bahan[0], bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
        videoPlayer.clip = recipe[flagFromChooseRecipe - 1].videos[0];
        //tools? ie imaget arget? ie flagTools(int)
        stepRecipeMax = recipe[flagFromChooseRecipe - 1].steps.Length;

        bahan.transform.localScale = bahan1.transform.localScale;  //set scale as bahan1
        bahan1.SetActive(false);
        
    }

    void LoadItems()
    {
        var recipeObj = Resources.LoadAll("ChooseRecipe", typeof(Recipe));
        foreach (var recipeDalamRecipeObj in recipeObj)
        {
            recipe.Add(recipeDalamRecipeObj as Recipe); //add a recipe scriptable into this class recipe scroptables  lsit
        }
    }

    public void changeText(string operation)
    {
        Destroy(bahan); //destroy prev bahan
        //bahan1.SetActive(true);
        if (operation == "plus")
        {
            if (stepIncrease < stepRecipeMax)
            {
                stepIncrease++;

            }
        }

        if (operation == "minus")
        {
            stepRecipeFirst = 1;

            if (stepIncrease > stepRecipeFirst)
            {
                stepIncrease--;
                
            }
        }

        if (stepIncrease == 1) //do this for SeterusnyaBUtton too?
        {
            //btnPrev.interactable = false;
            //btnNext.interactable = true;
            btnNext.gameObject.SetActive(true);
            btnPrev.gameObject.SetActive(false);

        }
        else if (stepIncrease == stepRecipeMax)
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

        //set recipe details as stepincrease means if stepincrease is 2, recipe step is 2
        /*foreach (var obj in recipe1)
        {
            if (obj.num == flagFromChooseRecipe)
            {
                tgameobject.text = obj.steps[stepIncrease - 1];
                bahan = Instantiate(obj.bahan[stepIncrease - 1], bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
                videoPlayer.clip = obj.videos[stepIncrease - 1];
            }
        }*/
        tgameobject.text = recipe[flagFromChooseRecipe - 1].steps[stepIncrease - 1];
        tgameobject.text = recipe[flagFromChooseRecipe - 1].steps[stepIncrease - 1];
        bahan = Instantiate(recipe[flagFromChooseRecipe - 1].bahan[stepIncrease - 1], bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
        
        videoPlayer.clip = recipe[flagFromChooseRecipe - 1].videos[stepIncrease - 1];

        bahan.transform.localScale = bahan1.transform.localScale; //set scale as bahan1
        
    }
    public void BackResipi()
    {
        SceneManager.LoadScene("PilihResipi");
    }

    public void ChangeStartStop()
    {
        if (videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
            buttonVid.image.sprite = stopSprite;
        }
        else
        {
            videoPlayer.Pause();
            buttonVid.image.sprite = startSprite;
        }
    }

}
