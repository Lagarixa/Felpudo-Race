using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PARALAXRRUN : MonoBehaviour
{
    public Controlamouseesquerdofds CausarDano;
    public int danoI = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CausarDano.TomarDano(danoI);
        }
    }
}