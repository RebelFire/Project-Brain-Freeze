using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem2 : MonoBehaviour
{
    private ParticleSystem pS;
    [SerializeField] private GameObject zombie;
    void Start()
    {
        pS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pS.Stop();
            zombie.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            pS.Play();
        }
    }
}
