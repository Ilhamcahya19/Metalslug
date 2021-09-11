using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(KillMe());
    }

    IEnumerator KillMe()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
