using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick mj; 
    public float velocidade; 
    private Rigidbody2D rb; 
    private Vector2 direcao = Vector2.zero; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
     float valorX = mj.Direction.x;
        float valorY = mj.Direction.y;

     
        float moduloX = Mathf.Abs(valorX);
        float moduloY = Mathf.Abs(valorY);

        if (moduloX > moduloY)
        {
            if (valorX < 0)
                setDirecao(Vector2.left);
            else
                setDirecao(Vector2.right);
        }
        else if (moduloY > moduloX)
        {
            if (valorY < 0)
                setDirecao(Vector2.down);
            else
                setDirecao(Vector2.up);
        }
        else
        {
            setDirecao(Vector2.zero);
        }
    }

    private void FixedUpdate()
    {
    
        Vector2 posicao =  rb.position;
        Vector2 novaposicao = direcao * velocidade * Time.fixedDeltaTime;// Move o personagem para a nova posição
        rb.MovePosition(posicao + novaposicao);
    }

    
    private void setDirecao(Vector2 novaDirecao)
    {
        direcao = novaDirecao;
    }
}
