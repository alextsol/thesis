using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class xButton : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Outside");
    }
}
