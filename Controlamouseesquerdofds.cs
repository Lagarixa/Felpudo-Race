using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Controlamouseesquerdofds : MonoBehaviour
{
    bool comecou;
    private int Vidas;
    bool acabou;
    public string sceneName;
    public Vector3 moveSpeed;
    public float changeTime;
    public string sceneEnd;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;



    Rigidbody2D corpoJogador;
    Vector2 forcaImpulso = new Vector2(0, 500f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject.SetActive(false);
        corpoJogador = GetComponent<Rigidbody2D>();
        Vidas = 1;
        moveSpeed = Vector2.right * Time.deltaTime;
    }
    void SetCountText()
    {
        countText.text = "Metros para a Fofura:" + changeTime.ToString();
        if (changeTime <= 0)
        {
            winTextObject.SetActive(true);
        }
    }
        // Update is called once per frame
        void Update()
    {
        changeTime -= Time.deltaTime;
        SetCountText();
        if (changeTime <= 0)
        {
            SceneManager.LoadScene(sceneEnd);
        }

        transform.position += moveSpeed;
        if (Input.GetButtonDown("Fire1"))
        {
            if (!comecou)
            {
                comecou = true;
                corpoJogador.bodyType = RigidbodyType2D.Dynamic;
            }
            corpoJogador.linearVelocity = new Vector2(0, 0);
            corpoJogador.AddForce(forcaImpulso);

        }
    }
   
    public void TomarDano(int Dano)
    {
        Vidas -= Dano;
        if (Vidas <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
