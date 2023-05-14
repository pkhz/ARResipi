using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Mula()
    {
        SceneManager.LoadScene("PilihResipi");
    }

    public void MarkerResipi()
    {
        SceneManager.LoadScene("MarkerResipi");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void Keluar()
    {
        Application.Quit();
    }

}
