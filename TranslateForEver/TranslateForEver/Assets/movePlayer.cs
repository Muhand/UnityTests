using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

    [SerializeField]
    GameObject target;
    private float slope;
    private float yintercept;
    private float nextY;
    private float nextX;

    // Update is called once per frame
    void FixedUpdate () {
        translateOverLine(gameObject, target.transform.position, 0.1f, 1000f);
    }

    void translateOverLine(GameObject objectToTransform, Vector3 direction, float step, float speed)
    {
        if ((direction.x-objectToTransform.transform.position.x != 0) && (direction.y - objectToTransform.transform.position.y != 0))
        {
            //Calculate Slope => (y1-y2)/(x1-x2)
            slope = (objectToTransform.transform.position.y - direction.y) / (objectToTransform.transform.position.x - direction.x);
            print("Slope: " + slope);

            //Calculate Y Intercept => y1-x1*m
            yintercept = objectToTransform.transform.position.y - (objectToTransform.transform.position.x * slope);
            print("Y Intercept: " + yintercept);

            //Next X
            if (target.transform.position.x > 0)
                nextX = objectToTransform.transform.position.x + step;
            else
                nextX = objectToTransform.transform.position.x - step;

            print("Next X is: " + nextX);

            //Calculate next Y
            nextY = (slope * nextX) + yintercept;
            print("Next y is: " + nextY);

            //Move
            objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, nextY, 0), speed * Time.deltaTime);
            
            if (objectToTransform.transform.position == direction)
            {
                print("YESSSSSSS");
                print("X: " + objectToTransform.transform.position.x);
                print("Y: " + objectToTransform.transform.position.y);

            }
        }
        else
        {
            if ((direction.x - objectToTransform.transform.position.x == 0) && (direction.y - objectToTransform.transform.position.y == 0))
            {
                //We are at the same position as the objective, therefore just return
                return;
            }
            if (direction.x - objectToTransform.transform.position.x == 0)
            {
                //If difference in X is 0 then we are at the same x point so we are moving vertically; therefore just move up or down depending on target's Y

                if (direction.y > 0)
                {
                    nextY = objectToTransform.transform.position.y + step;
                    
                    objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(objectToTransform.transform.position.x, nextY, 0), speed * Time.deltaTime);
                }
                else if (direction.y < 0)
                {
                    nextY = objectToTransform.transform.position.y - step;

                    objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(objectToTransform.transform.position.x, nextY, 0), speed * Time.deltaTime);
                }

            }
            else if(direction.y - objectToTransform.transform.position.y == 0)
            {
                if (direction.x > 0)
                {
                    nextX = objectToTransform.transform.position.x + step;

                    objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, objectToTransform.transform.position.y, 0), speed * Time.deltaTime);
                }
                else if (direction.y < 0)
                {
                    nextX = objectToTransform.transform.position.x - step;

                    objectToTransform.transform.position = Vector3.MoveTowards(objectToTransform.transform.position, new Vector3(nextX, objectToTransform.transform.position.y, 0), speed * Time.deltaTime);
                }

            }
        }
    }
   
}
