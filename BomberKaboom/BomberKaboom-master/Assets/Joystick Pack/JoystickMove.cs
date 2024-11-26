using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick mj; 
    public float velocidade;
    private Rigidbody2D rb;
    private Vector2 direcao = Vector2.down;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Script Inicializado");
    }

    public void FixedUpdate()
    {
        if (mj.Direction != Vector2.zero)
        {
            Vector2 posicao = rb.position;
            Vector2 resultado = velocidade * mj.Direction * Time.fixedDeltaTime; // Use a direção do joystick
            rb.MovePosition(posicao + resultado);
            Debug.Log("Movendo: " + resultado);
        }
        else
        {
            rb.velocity = Vector2.zero;
            Debug.Log("Parado");
        }
    }

    public void Atualiza() // esse método verifica qual distância é maior, com base nisso realiza o movimento 
    {
        float valorX = mj.Direction.x, valorY = mj.Direction.y;
        float moduloX = Mathf.Abs(valorX), moduloY = Mathf.Abs(valorY);

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
        Debug.Log("Direção: " + direcao);
    }

    public void setDirecao(Vector2 novaDirecao)
    {
        direcao = novaDirecao;
    }
}
