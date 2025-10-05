using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidVision : MonoBehaviour
{
    public GameObject asteroidModel;     // первый астероид
    public GameObject asteroidModel2;    // второй астероид
    public GameObject pointSprite;
    public Canvas Canvas;

    private bool showingPoint = false;
    private const float targetX = 511f;  // общая цель для встречи
    private const float targetX2 = 489f;  // общая цель для встречи
    private string trajectory = "straight";

    void Start()
    {
        pointSprite.SetActive(showingPoint);
    }

    public void TogglePoint()
    {
        showingPoint = !showingPoint;

        asteroidModel.SetActive(!showingPoint);
        pointSprite.SetActive(showingPoint);

        if (showingPoint)
        {
            pointSprite.transform.position = asteroidModel.transform.position;
        }
    }

    void Update()
    {
        if (showingPoint && trajectory == "straight")
        {
            pointSprite.transform.position = asteroidModel.transform.position;

            float baseSpeed = Canvas.GetComponent<FormHandler>().speed * 1000f; // базовая скорость для расчёта

            // Расстояния до цели
            float distance1 = Mathf.Abs(targetX - asteroidModel.transform.position.x);
            float distance2 = Mathf.Abs(targetX - asteroidModel2.transform.position.x);

            // Время, за которое нужно достичь цели (берём базовую скорость и первый астероид)
            float timeToReach = distance1 / baseSpeed;

            // Вычисляем индивидуальные скорости для синхронного прибытия
            float speed1 = distance1 / timeToReach;
            float speed2 = distance2 / timeToReach;

            // Двигаем первый астероид
            Vector3 targetPos1 = new Vector3(targetX, asteroidModel.transform.position.y, asteroidModel.transform.position.z);
            asteroidModel.transform.position = Vector3.MoveTowards(
                asteroidModel.transform.position,
                targetPos1,
                speed1 * Time.deltaTime
            );

            // Двигаем второй астероид
            //Vector3 targetPos2 = new Vector3(targetX2, asteroidModel2.transform.position.y, asteroidModel2.transform.position.z);
            //asteroidModel2.transform.position = Vector3.MoveTowards(
            //    asteroidModel2.transform.position,
            //    targetPos2,
            //    speed2 * Time.deltaTime
            //);
        }
    }
}
