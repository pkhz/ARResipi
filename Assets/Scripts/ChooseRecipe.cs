using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choose Recipe", menuName = "Sriptables/ChooseRecipe")]
public class ChooseRecipe : ScriptableObject
{
    public int num;

    public string recipeName;

    public GameObject makanan;

    public GameObject[] bahan;

    public GameObject[] bahanName;

    public Sprite recipeImage;
}
