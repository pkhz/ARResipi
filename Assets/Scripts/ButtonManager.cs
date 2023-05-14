using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    //choose recipe button
    private Button btn;
    [SerializeField] private RawImage btnImage;

    private int btnId;
    private Sprite btnTexture;

    public Sprite BtnTexture
    {
        set
        {
            btnTexture = value;
            btnImage.texture = btnTexture.texture;
        }
    }

    public int BtnId
    {
        set { btnId = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        //basically call class thorugh instance and pass this gameobject taht is btn
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.2f); //(scale, speed of animation) //scale but has doscale which has animation too
           // transform.localScale = Vector3.one * 2; temp
        }
        else
        {
            transform.DOScale(Vector3.one, 0.2f);
            //transform.localScale = Vector3.one; temp
        }
    }

    void SelectObject()
    {
        //DataHandler.Instance.SetRecipe(btnId);
        //Debug.Log(btnId);
        //make same as changetext plusminus button next prev bahan
        //or maybe just make a global function?
        //plus minus stepcounter
        //if btnid-1 == stepcounter
        //bahan = Instantiate(DataHandler.Instance.GetRecipeBahan()[id], tempatBahan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform); //change canvas tag later
        //bahan.transform.localScale = bahan1.transform.localScale;
        //need to destroy?

        //bahan = Instantiate(DataHandler.Instance.GetRecipeBahan()[btnId], tempatBahan.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform); //change canvas tag later
        //bahan.transform.localScale = tempatBahan.transform.localScale;

        BahanSeterusnyaButton.InstanceSeterusnya.fillPanel(btnId);

        //PlayerPrefs.SetInt("choosenRecipeId", btnId);
        //Debug.Log(PlayerPrefs.GetInt("choosenRecipeId"));
    }
}
