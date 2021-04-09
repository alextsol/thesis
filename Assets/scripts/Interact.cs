using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    [SerializeField]
    public GameObject textA;
    public GameObject textB;
    public GameObject textC;

    public void Update()
    {
        //gia check tn apo kinhto 
        if (textA.activeInHierarchy && !(SceneManager.GetActiveScene().name == "First Class"))
        {
            if(Input.touchCount==1)
            {
                LoadScene("First Class");
            }
        }
        else if (textB.activeInHierarchy && !(SceneManager.GetActiveScene().name == "Second Class"))
        {
            if (Input.touchCount == 1)
            {
                LoadScene("Second Class");
            }
        }
        else if (textC.activeInHierarchy && !(SceneManager.GetActiveScene().name == "Third Class"))
        {
            if (Input.touchCount == 1)
            {
                LoadScene("Third Class");
            }
        }
        
        //gia check tn apo PC
        if (textA.activeInHierarchy && !(SceneManager.GetActiveScene().name == "First Class"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene("First Class");
            }
        }
        else if (textB.activeInHierarchy && !(SceneManager.GetActiveScene().name == "Second Class"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene("Second Class");
            }
        }
        else if (textC.activeInHierarchy && !(SceneManager.GetActiveScene().name == "Third Class"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadScene("Third Class");
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    #region Cols gia na emfanizei to notate an phgainei dipla sto 8ranio 

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name=="triggerA")
        {
            textA.SetActive(true);
            StartCoroutine("WaitforSec");
        }
        else if (col.gameObject.name == "triggerB")
        {
            textB.SetActive(true);
            StartCoroutine("WaitforSec");
        }
        else if (col.gameObject.name == "triggerC")
        {
            textC.SetActive(true);
            StartCoroutine("WaitforSec");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "triggerA")
        {
            textA.SetActive(false);
        }
        else if(col.gameObject.name=="triggerB")
        {
            textB.SetActive(false);
        }
        else if(col.gameObject.name=="triggerC")
        {
            textC.SetActive(false);
        }
    }
    IEnumerator WaitforSec()
    {
        yield return new WaitForSeconds(3);
    }
    #endregion
}