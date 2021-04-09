using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class DoorFramePlacement : MonoBehaviour
{
    private GameObject spawnObject;

    [SerializeField]
    public GameObject portal;
    public GameObject building;

    public Button pdBtn, bBtn;

    private bool isActive = false;
    private bool isBActive = false;

    //trexei prin thn start 
    //dhmiourgoume ena array wste na kanoume ta components na mhn fainontai 
    void Awake()
    {
        Renderer[] rs = building.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;

        //kati paromoio me to panw k molis patas to koumpi na emfanizetai h porta 
        Renderer[] tF = portal.GetComponentsInChildren<Renderer>();
        foreach (Renderer t in tF)
            t.enabled = false;
    }

    public void PortalDoorSpawner()
    {
        if (!isActive)
        {
            Renderer[] sP = portal.GetComponentsInChildren<Renderer>();
            foreach (Renderer p in sP)
                p.enabled = true;

            pdBtn.gameObject.SetActive(false);
        }
    }

    public void BuildingSpanwer()
    {
        if (!isBActive) { 
            spawnObject = Instantiate(building, building.transform.position, building.transform.rotation);

            Renderer[] rs = spawnObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
              r.enabled = true;

            Renderer[] sP = portal.GetComponentsInChildren<Renderer>();
            foreach (Renderer p in sP)
              p.enabled = false;

             isBActive = true;
             bBtn.gameObject.SetActive(false);
        }
    }
}
