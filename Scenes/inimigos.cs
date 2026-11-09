using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;

    public float interval = 3f;
    public float limiteX = 8f;
    public float limiteY = 4f;
    public float velocidade = 3f;
    public float limiteDestruicaoX = -12;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("GerarInimigo", 0f, interval);
    }

    void GerarInimigo()
    {
        float x = limiteX;
        float y = Random.Range(-limiteY, limiteY);
        Vector2 pisocaoAleatoria = new Vector2(x, y);

        GameObject inimigo = Instantiate(inimigoPrefab, pisocaoAleatoria, Quaternion.identity);

        StartCoroutine(MoverInimigo(inimigo));
    }
    IEnumerator MoverInimigo(GameObject inimigo)
    {
        while (inimigo != null)
        {
            inimigo.transform.Translate(Vector2.left * velocidade * Time.deltaTime);

            if (inimigo.transform.position.x < limiteDestruicaoX)
            {
                Destroy(inimigo);
                yield break;
            }
            yield return null;
        }
    }
    void Update()
    {
        
    }
}
