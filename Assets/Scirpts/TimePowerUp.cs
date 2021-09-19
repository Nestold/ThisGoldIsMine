using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem timeParticleSystem = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddTime();
        var parSys = Instantiate(timeParticleSystem);
        parSys.transform.position = transform.position;
        GameManager.Instance.UIManager.ShowOnMoreMinute();
        Destroy(gameObject);
    }
}
