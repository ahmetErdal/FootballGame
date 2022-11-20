using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagers : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManagers instace;
    private void Awake()
    {
        instace = this;
    }
    public int needTouchBall;
    public int needTimeStals;

    public void CompleteCheckLevel()
    {
        if (FootController.instance.bounceCount==needTouchBall)
        {
            FootController.instance.countText.text = "Count: Success";
        }
        if (FootController.instance.touchTimeBall==needTimeStals)
        {
            FootController.instance.touchTimeText.text = "Stals: Success";
        }
        if (FootController.instance.bounceCount >= needTouchBall && FootController.instance.touchTimeBall >= needTimeStals)
        {

            UIManager.instance.SuccessLevel();
        }
    }
}
