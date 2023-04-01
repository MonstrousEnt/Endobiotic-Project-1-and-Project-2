using UnityEngine;

public struct Robot
{
    public Robot(Form a_form, Vector3 a_position)
    {
        formRobot = a_form;
        positionRobot = a_position;
    }

    public Form formRobot;
    public Vector3 positionRobot;
}
