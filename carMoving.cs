using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMoving : MonoBehaviour {

    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider backRingtWheel;
    public WheelCollider backLeftWheel;


	public float DragDistance;
	Vector3 fp,lp;


    void Update()
    {
        frontLeftWheel.brakeTorque = 100;
        frontRightWheel.brakeTorque = 100;
        backLeftWheel.brakeTorque = 100;
        backRingtWheel.brakeTorque = 100;

		//PCcontroll ();
		MobileControll ();
    }

    public IEnumerator DoJump(WheelCollider wheel1, WheelCollider wheel2)
    {
        JointSpring spring = wheel1.suspensionSpring;
        while (spring.targetPosition > 0f)
        {
            spring.targetPosition -= 10f * Time.deltaTime;
            if (spring.targetPosition < 0)
                spring.targetPosition = 0;

            wheel1.suspensionSpring = spring;
            wheel2.suspensionSpring = spring;
            yield return null;
        }

        StartCoroutine(DoBack(wheel1, wheel2));
    }

    IEnumerator DoBack(WheelCollider wheel1, WheelCollider wheel2)
    {
        yield return new WaitForSeconds(0.1f);
        JointSpring spring = wheel1.suspensionSpring;
        while (spring.targetPosition < 0.6f)
        {
            spring.targetPosition += 10f * Time.deltaTime;
            if (spring.targetPosition > 0.6f)
                spring.targetPosition = 0.6f;

            wheel1.suspensionSpring = spring;
            wheel2.suspensionSpring = spring;
            yield return null;
        }
    }


	void PCcontroll() {
		        if (Input.GetKeyDown("w"))
		            StartCoroutine(DoJump(frontLeftWheel, frontRightWheel));
		
		        if (Input.GetKeyDown("a"))
		            StartCoroutine(DoJump(frontLeftWheel, backLeftWheel));
		
		        if (Input.GetKeyDown("d"))
		            StartCoroutine(DoJump(frontRightWheel, backRingtWheel));
		
		        if (Input.GetKeyDown("s"))
		            StartCoroutine(DoJump(backLeftWheel, backRingtWheel));
	}

	void MobileControll() {
		//Check the touch inputs
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				fp = touch.position;
				lp = touch.position;
			}

			if (touch.phase == TouchPhase.Moved) {
				lp = touch.position;
			}

			if (touch.phase == TouchPhase.Ended) {
				//First check if it’s actually a drag
				if (Mathf.Abs (lp.x - fp.x) > DragDistance || Mathf.Abs (lp.y - fp.y) > DragDistance) { //It’s a drag
					//Now check what direction the drag was
					//First check which axis
					if (Mathf.Abs (lp.x - fp.x) > Mathf.Abs (lp.y - fp.y)) {
						//If the horizontal movement is greater than the vertical movement…
						if (lp.x > fp.x) { //Right move
							ScoreManager.instance.CheckArrowsInput("Right");
							StartCoroutine(DoJump(frontRightWheel, backRingtWheel));

						} else { //Left move
							ScoreManager.instance.CheckArrowsInput("Left");
							StartCoroutine(DoJump(frontLeftWheel, backLeftWheel));
						}
					} else {
						//the vertical movement is greater than the horizontal movement
						if (lp.y > fp.y) {
							//Up move
							ScoreManager.instance.CheckArrowsInput("Up");
							StartCoroutine(DoJump(frontLeftWheel, frontRightWheel));
						} else {
							//Down move
							ScoreManager.instance.CheckArrowsInput("Down");
							StartCoroutine(DoJump(backLeftWheel, backRingtWheel));

						}
					}
				} else {
					//It’s a tap

				}
			}
		}
	}
}
