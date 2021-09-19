using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject moreObject = null;


    public void FireMore()
    {
        if (moreObject != null)
            moreObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
