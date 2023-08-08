using System;
using UnityEngine;

public class MovementAutomatic : MonoBehaviour
{
    enum TypeMovementBot { HorizontalBounce, VerticalBounce, HorizontalFromLeft, HorizontalFromRight, VerticalFromAbove, VerticalFromBelow }

    [SerializeField] TypeMovementBot typeMovementRobot;
    [SerializeField] float limit;
    private Transform t;
    private int randomInt;
    private float speed = 1f;
    private float posicionInicial;
    private void Awake()
    {
        t = GetComponent<Transform>();
    }

    private void Start()
    {
        randomInt = UnityEngine.Random.Range(0, 2);
        posicionInicial = t.position.x;
    }

    private void Update()
    {
        switch (typeMovementRobot)
        {
            case TypeMovementBot.HorizontalBounce:
                HorizontalBounce();
                break;
            case TypeMovementBot.VerticalBounce:
                VerticalBounce();
                break;
            case TypeMovementBot.HorizontalFromLeft:
                HorizontalFromLeft();
                break;
            case TypeMovementBot.HorizontalFromRight:
                HorizontalFromRight();
                break;
            case TypeMovementBot.VerticalFromAbove:
                VerticalFromAbove();
                break;
            case TypeMovementBot.VerticalFromBelow:
                VerticalFromBelow();
                break;
        }
    }

    public void HorizontalBounce()
    {
        float movement = speed * Time.deltaTime;

        if (randomInt == 0)
        {
            t.position += new Vector3(movement, 0f, 0f); // se mueve hacia la derecha
            if (t.position.x >= posicionInicial + limit) // si es mayor a el limite positivo rebotar
            {
                randomInt = 1;
            }
        }
        else
        {
            t.position += new Vector3(-movement, 0f, 0f); // se mueve hacia la izquierda
<<<<<<< Updated upstream
            if (t.position.x <= limit) // si es menor al limite negativo rebotar
=======
            if (t.position.x <= posicionInicial -limit) // si es menor al limite negativo rebotar
>>>>>>> Stashed changes
            {
                randomInt = 0;
            }
        }
    }

    private void VerticalBounce()
    {
        float movement = speed * Time.deltaTime;

        if (randomInt == 0)
        {
            t.position += new Vector3(0f, movement, 0f); // se mueve hacia arriba
            if (t.position.y >= posicionInicial + limit) // si es mayor a el limite positivo rebotar
            {
                randomInt = 1;
            }
        }
        else
        {
            t.position += new Vector3(0f, -movement, 0f); //se mueve hacia abajo
            if (t.position.y <= posicionInicial -limit) // si es menor al limite negativo rebotar
            {
                randomInt = 0;
            }
        }
    }

    private void HorizontalFromLeft()
    {

        float movement = speed * Time.deltaTime;

        if (t.position.x <= posicionInicial + limit)
        {
            t.position = new Vector3(75.5f, -16.9f, 3); // si toca el borde, se teletransporta al limite opuesto
        }
        t.position += new Vector3(-movement, 0f, 0f); //se mueve hacia la izquierda
    }

    private void HorizontalFromRight()
    {
        float movement = speed * Time.deltaTime;

        if (t.position.x <= posicionInicial + limit)
        {
            t.position = new Vector3(posicionInicial, t.position.y, t.position.z); // si toca el borde, se teletransporta al limite opuesto
        }
        t.position += new Vector3(-movement, 0f, 0f); //se mueve hacia la izquierda
    }

    private void VerticalFromAbove()
    {
        float movement = speed * Time.deltaTime;

        if (t.position.y <= posicionInicial -limit)
        {
            t.position = new Vector3(t.position.x, limit, t.position.z); // si toca el borde, se teletransporta al limite opuesto
        }
        t.position += new Vector3(0f, -movement, 0f); //se mueve hacia abajo
    }

    private void VerticalFromBelow()
    {
        float movement = speed * Time.deltaTime;

        if (t.position.y >= posicionInicial + limit)
        {
            t.position = new Vector3(t.position.x, -limit, t.position.z); // si toca el borde, se teletransporta al limite opuesto
        }
        t.position += new Vector3(0f, movement, 0f); //se mueve hacia arriba
    }
}