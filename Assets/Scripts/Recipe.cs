using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Sriptables/Recipe")]
public class Recipe : ScriptableObject
{
    public int num;

    public string recipeName;

    public GameObject makanan;

    public string[] steps;

    public GameObject[] bahan;

    public VideoClip[] videos;

}
