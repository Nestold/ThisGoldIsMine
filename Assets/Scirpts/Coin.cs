using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem coinParticleSystem = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddCoin();
        var parSys = Instantiate(coinParticleSystem);
        parSys.transform.position = transform.position;
        Destroy(gameObject);
    }
}
