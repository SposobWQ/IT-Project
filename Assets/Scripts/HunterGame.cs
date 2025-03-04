using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterGame : MonoBehaviour
{
    [SerializeField] private RectTransform rectArea;
    [SerializeField] private RectTransform slideArea;
    [SerializeField] private RectTransform hunterArea;
    
    
    private bool isHunting = false;
    private Vector3 startPosition;
    private float cursorPositionX;
    
    public float CursorSpeed = 1f;
    
    private void Start()
    {
        startPosition = hunterArea.localPosition;
    }
    
    private void Update()
    {
        cursorPositionX = slideArea.localPosition.x;
        
        if (Input.GetMouseButtonDown(1) && !isHunting)
        {
            isHunting = true;
        }

        if (isHunting)
        {   //fishingArea.localPosition =  Mathf.PingPong(Time.time * fishingAreaSpeed, fishingAreaHeight.rect.height - 40) - (fishingAreaHeight.rect.height - 40) / 2
            slideArea.localPosition = new Vector3(Mathf.PingPong(Time.time * CursorSpeed, rectArea.rect.width - slideArea.rect.width) - (rectArea.rect.width - slideArea.rect.width) / 2, slideArea.localPosition.y, slideArea.localPosition.z);

            if (hunterArea.localPosition.x == startPosition.x)
            {
                randomImagePosition();
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (checkPosition())
                {
                    randomImagePosition();
                }
            }
        }
    }

    private bool checkPosition()
    {
        float hunterAreaMinX = hunterArea.transform.localPosition.x - hunterArea.rect.width / 2;
        float hunterAreaMaxX = hunterArea.transform.localPosition.x + hunterArea.rect.width / 2;
        
        return cursorPositionX >= hunterAreaMinX && cursorPositionX <= hunterAreaMaxX;
    }

    private void randomImagePosition()
    {
        hunterArea.localPosition = new Vector3(Random.Range(rectArea.localPosition.x - rectArea.rect.width/2, rectArea.localPosition.x + rectArea.rect.width/2), hunterArea.localPosition.y, hunterArea.localPosition.z);
    }
}
