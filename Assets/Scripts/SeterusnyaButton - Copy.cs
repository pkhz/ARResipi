using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;

//backup 26122022
public class SeterusnyaButtonC : MonoBehaviour //ori - SeterusnyaButton
{
    Text tgameobject;
    GameObject bahan;
    GameObject gameObjectModelTarget;

    public Recipe[] recipe1;

    public Recipe recipe2;

    //List<GameObject> bahan;
    public GameObject bahan1;
    public GameObject bahan2;
    public GameObject bahan3;

    public GameObject[] modelTarget; //get modeltarget prefabs

    public VideoClip video;
    public VideoClip video2;
    
    private VideoPlayer videoPlayer;
    
    int flagFromChooseRecipe = 2; //temp, actually took value pass from prev scene

    int stepIncrease = 1; //start from step1
    int stepRecipe;
    int stepRecipeFirst;
    int stepRecipeMax;
    //ModelTargetBehaviour b;

    // Start is called before the first frame update
    void Start()
    {
        tgameobject = GameObject.FindGameObjectWithTag("step1").GetComponent<Text>();
        bahan = GameObject.FindGameObjectWithTag("bahan");
        gameObjectModelTarget = GameObject.Find("ModelTarget");

        

        //modelTarget = ;
        videoPlayer = GameObject.FindGameObjectWithTag("videoplane").GetComponent<VideoPlayer>();

        foreach (var obj in recipe1)
        {
            //instantiate with first index of array as step 1 is first index
            if (obj.num == flagFromChooseRecipe)
            {
                tgameobject.text = obj.steps[0];
                bahan = Instantiate(obj.bahan[0],bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
                videoPlayer.clip = obj.videos[0];
                //tools? ie imaget arget? ie flagTools(int)
                stepRecipeMax = obj.steps.Length;
            }
        }

        bahan.transform.localScale = bahan1.transform.localScale;  //set scale as bahan1
        
        //foreach (var obj in modelTarget)
        //{

            //if (obj.index == (flagTools-1))
            //{
                gameObjectModelTarget = Instantiate(modelTarget[1], modelTarget[1].transform.position, Quaternion.identity);
            // }
        //}
        //bahan.SetActive(true);
        //videoPlayer.clip = video;
        //stepIncrease = 1;
        //bahan.Add(GameObject.Find("Bahan1"));
        //bahan.Add(GameObject.Find("Bahan2"));
        //bahan.Add(GameObject.Find("Bahan3"));

        //bahan1 = GameObject.Find("Bahan1");
        //bahan2 = GameObject.Find("Bahan2");
        //bahan3 = GameObject.Find("Bahan3");
        //bahan1.SetActive(false);


        //bahan1 = bahan, //bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
        //Destroy(bahan);
        //bahan1.SetActive(true);

        bahan2.SetActive(false);
        bahan3.SetActive(false);
        //b.data = 
    }

    public void changeText(string operation)
    {
        Destroy(bahan); //destroy prev bahan
        //bahan1.SetActive(true);
        if (operation == "plus")
        {
            //need to have do while of specific recipe step number(pass from prev scene)
            //stepRecipeMax = 3; //eg if recipe ends at step 3, set as 3

            if (stepIncrease < stepRecipeMax)
            {
                stepIncrease++;

                //tgameobject.text = "Step " + stepIncrease;

            }
        }

        if (operation == "minus")
        {
            //need to have do while of specific recipe step number(pass from prev scene)
            stepRecipeFirst = 1;

            if (stepIncrease > stepRecipeFirst)
            {
                stepIncrease--;
                //tgameobject.text = "Step " + stepIncrease;

                //real algo here?
                //theory algo:
                //tgameobject.text,..etc = json take from stepincrease int
                //bahan in list?
            }
        }

        foreach (var obj in recipe1)
        {
            if (obj.num == flagFromChooseRecipe)
            {
                tgameobject.text = obj.steps[stepIncrease - 1];
                bahan = Instantiate(obj.bahan[stepIncrease - 1], bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
                //bahan = obj.bahan[stepIncrease - 1];
                videoPlayer.clip = obj.videos[stepIncrease - 1];
            }
        }
        bahan.transform.localScale = bahan1.transform.localScale; //set scale as bahan1
        //bahan1 = Instantiate(bahan, bahan1.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
        //Destroy(bahan);
        //bahan1.SetActive(false);
        //test
        /*if (stepIncrease == 1)
        {
            
            //tgameobject.text = recipe1.steps[0];
            bahan1.SetActive(true);
            bahan2.SetActive(false);
            bahan3.SetActive(false);
            videoPlayer.clip = video;
        }
        else if (stepIncrease == 2)
        {
            //tgameobject.text = "Step " + stepIncrease + "ini step 2";
            bahan1.SetActive(false);
            bahan2.SetActive(true);
            bahan3.SetActive(false);
            videoPlayer.clip = video2;
        }
        else if (stepIncrease == 3)
        {
            tgameobject.text = "Step " + stepIncrease + "ini step 3";
            bahan1.SetActive(false);
            bahan2.SetActive(false);
            bahan3.SetActive(true);
            videoPlayer.clip = video;
        }
        else
            tgameobject.text = "error:should not trigger"; */
    }

    public void changeTextStep()
    {
        changeText("plus");
       /* stepIncrease += 1; //need to have do while of specific recipe step number(pass from prev scene)
        stepRecipeMax = 3;
        
        if (stepIncrease <= stepRecipeMax){
            tgameobject.text = "Step " + stepIncrease;
            Debug.Log(stepIncrease);
            //bahan[stepIncrease].SetActive(false);
            //bahan[stepIncrease+1].SetActive(true);
             switch (stepIncrease)
             {
                 case 1:
                     bahan1.SetActive(true);
                     bahan2.SetActive(false);
                     bahan3.SetActive(false);
                     break;
                 case 2:
                     bahan1.SetActive(false);
                     bahan2.SetActive(true);
                     bahan3.SetActive(false);
                     break;
                 case 3:
                     bahan1.SetActive(false);
                     bahan2.SetActive(false);
                     bahan3.SetActive(true);
                     break;
             }
        }*/
    }

    public void changeTextStepDecrease()
    {
        changeText("minus");
        /*stepIncrease -= 1; //need to have do while of specific recipe step number(pass from prev scene)
        stepRecipeMax = 0;

        if (stepIncrease >= stepRecipeMax)
        {
            tgameobject.text = "Step " + stepIncrease;
            Debug.Log(stepIncrease);
            //bahan[stepIncrease].SetActive(false);
            //bahan[stepIncrease+1].SetActive(true);
            switch (stepIncrease)
            {
                case 1:
                    bahan1.SetActive(true);
                    bahan2.SetActive(false);
                    bahan3.SetActive(false);
                    break;
                case 2:
                    bahan1.SetActive(false);
                    bahan2.SetActive(true);
                    bahan3.SetActive(false);
                    break;
                case 3:
                    bahan1.SetActive(false);
                    bahan2.SetActive(false);
                    bahan3.SetActive(true);
                    break;
            }
        }*/
    }

    
    // Update is called once per frame
    //void Update()
    //{

    //}
}
