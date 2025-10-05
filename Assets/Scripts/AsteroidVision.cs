using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidVision : MonoBehaviour
{
    public GameObject asteroidModel;
    public GameObject pointSprite;
    public Camera mainCamera;
    
    private bool showingPoint = false;

    void Start()
    {
        if (!showingPoint)
            pointSprite.SetActive(showingPoint);
    }

    public void TogglePoint()
    {
        showingPoint = !showingPoint;

        asteroidModel.SetActive(!showingPoint);
        pointSprite.SetActive(showingPoint);

        if (showingPoint)
            pointSprite.transform.position = mainCamera.WorldToScreenPoint(asteroidModel.transform.position);
    }

    void Update()
    {
        if (showingPoint)
        {
            pointSprite.transform.position = mainCamera.WorldToScreenPoint(asteroidModel.transform.position);
        }
    }
}
