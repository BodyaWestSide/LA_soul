using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControll : MonoBehaviour {

	//First/Last finger position
	Vector3 fp,lp;

	//Distance needed for a swipe to take some Action
	public float DragDistance;

	void Update()
	{
		//Check the touch inputs
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}

			if (touch.phase == TouchPhase.Moved)
			{
				lp = touch.position;
			}

			if (touch.phase == TouchPhase.Ended)
			{
				//First check if it’s actually a drag
				if (Mathf.Abs(lp.x - fp.x) > DragDistance || Mathf.Abs(lp.y - fp.y) > DragDistance)
				{ //It’s a drag
					//Now check what direction the drag was
					//First check which axis
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{
						//If the horizontal movement is greater than the vertical movement…
						if (lp.x > fp.x)
						{ //Right move
							
						}
						else
						{ //Left move
							
						}
					}
					else
					{
						//the vertical movement is greater than the horizontal movement
						if (lp.y > fp.y)
						{
							//Up move

						}
						else
						{
							//Down move

						}
					}
				}
				else
				{
					//It’s a tap

				}
			}
		}
	}
}
