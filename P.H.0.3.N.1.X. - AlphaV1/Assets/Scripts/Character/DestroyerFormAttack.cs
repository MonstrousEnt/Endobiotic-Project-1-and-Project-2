using UnityEngine;

public class DestroyerFormAttack : MonoBehaviour
{
    #region Class Variables
    //Reference to player controller animations
    [SerializeField] PlayerControllerAnimations m_playerControllerAnimations;
    #endregion

    #region Unity Methods
    private void Update()
    {
       //Null Check for player animation
        if (m_playerControllerAnimations == null)
        {
            return;
        }

        //When the play press the Form Action
        if (Input.GetButton("FormAction"))
        {
            //Run player destroyer attack animation
            m_playerControllerAnimations.DestroyerAttack();
        }
    }
    #endregion
}
