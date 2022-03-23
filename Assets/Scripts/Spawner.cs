using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Item> spawnList = new List<Item>();

    bool hasDropped = true;
    ItemManager spawnedObject;

    //Touch
    Vector3 startPos;
    float startTime;
    bool isTouch = false;
    float minSwipeDistX;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        minSwipeDistX = Screen.width / 6;
    }

    void Update()
    {
        if (spawnedObject == null)
        {
            hasDropped = true;
        }

        if (hasDropped)
        {
            if (!IsInvoking(nameof(Spawn)))
            {
                Invoke(nameof(Spawn), 1f);
            }
        }

        // HandleInput();
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            DropObject();
        }
        else if (Input.GetKeyUp(KeyCode.RightAlt))
        {
            RotateObjectRight();
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            RotateObjectLeft();
        }
    }

    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    startTime = Time.time;
                    break;
                case TouchPhase.Moved:
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0 && !isTouch)//to right swipe
                        {
                            isTouch = true;
                            RotateObjectLeft();
                        }
                        else if (swipeValue < 0 && !isTouch)//to left swipe
                        {
                            isTouch = true;
                            RotateObjectRight();
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (!isTouch)
                    {
                        DropObject();
                    }
                    isTouch = false;
                    break;
            }
        }
    }

    void Spawn()
    {
        float startPos = transform.position.x - (transform.localScale.x / 2);
        float endPos = transform.position.x + (transform.localScale.x / 2);

        Vector3 startVec = new Vector3(startPos, transform.position.y - 0.8f, transform.position.z);
        Vector3 endVec = new Vector3(endPos, transform.position.y - 0.8f, transform.position.z);

        int randomIndex = Random.Range(0, spawnList.Count);
        spawnedObject = Instantiate(spawnList[randomIndex].itemPrefab, startVec, Quaternion.identity).GetComponent<ItemManager>();
        float randomScale = Random.Range(spawnList[randomIndex].sizeRange[0], spawnList[randomIndex].sizeRange[1]);
        spawnedObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        int scoreValue = (int)(randomScale * spawnList[randomIndex].valueMultiplier);

        spawnedObject.Init(startVec, endVec, scoreValue);
        hasDropped = false;
    }

    void RotateObjectRight()
    {
        if (spawnedObject == null)
        {
            return;
        }

        spawnedObject.transform.Rotate(0, 0, 90);
    }

    void RotateObjectLeft()
    {
        if (spawnedObject == null)
        {
            return;
        }

        spawnedObject.transform.Rotate(0, 0, -90);
    }

    void DropObject()
    {
        if (spawnedObject == null)
        {
            return;
        }

        spawnedObject.Drop();

        hasDropped = true;
        spawnedObject = null;
    }
}
