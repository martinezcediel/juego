using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymov : MonoBehaviour
{
    private bool isMoving;
    private float speed;
    //private float totalSeconds = 0.5f;
    public Vector3 targetPos;
    private float WaitForSeconds = 0.5f;
    private float disCube = 2;
    public int actualWaypoint = 1;

    private walls wallsscript; // Llamo al script de walls


    public GameObject[] wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        wallsscript = FindObjectOfType<walls>();
       

        transform.position = wayPoints[0].transform.position;


        targetPos = wayPoints[actualWaypoint].transform.position;

        transform.LookAt(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            StartCoroutine(Move(targetPos, WaitForSeconds));

        }

        if (transform.position == targetPos)
        {
            actualWaypoint = (actualWaypoint + 1) % wayPoints.Length;

            targetPos = wayPoints[actualWaypoint].transform.position;

            transform.LookAt(targetPos);
        }

    }

    private IEnumerator Move(Vector3 targetPosition, float duration)
    {
        if (isMoving) yield break; // Si nos estamos moviendo, nada

        // Si estábamos quietos, iniciamos movimiento
        isMoving = true;

        wallsscript.wallposition.Remove(transform.position);
        wallsscript.wallposition.Add(targetPosition);
      

        yield return new WaitForSeconds(WaitForSeconds);

        // Configuramos la velocidad en función de la distancia a recorrer y el tiempo total del recorrido
        speed = disCube / duration;

        duration = Vector3.Distance(transform.position, targetPosition) / disCube * duration;

        float passedTime = 0f;
        float D = 0;
        Vector3 previousPos = transform.position;

        // Mientras el tiempo transcurrido no supere la duración total, nos movemos hacia targetPos
        while (passedTime < duration)
        {
            if (D >= disCube)
            {
                yield return new WaitForSeconds(WaitForSeconds);
                D = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos,
                speed * Time.deltaTime);

            // Aumentamos el tiempo transcurrido
            passedTime += Time.deltaTime;

            D += Vector3.Distance(transform.position, previousPos);

            previousPos = transform.position;

            // Pasamos al siguiente frame
            yield return null;

        }

        // Al acabar, nos aseguramos de que nuestra posición, sea la posición objetivo
        transform.position = targetPosition;
        // Ya no nos movemos
        isMoving = false;
    }
}
