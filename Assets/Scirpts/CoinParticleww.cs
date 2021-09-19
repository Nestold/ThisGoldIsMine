using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticleww : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
