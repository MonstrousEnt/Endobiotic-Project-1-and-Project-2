/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: April 1, 2023
 * Last Updated: April 2, 2023
 * Description: This is the strut is for enemy robot object.
 * Notes: 
 * Resources: 
 *  
 */

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
