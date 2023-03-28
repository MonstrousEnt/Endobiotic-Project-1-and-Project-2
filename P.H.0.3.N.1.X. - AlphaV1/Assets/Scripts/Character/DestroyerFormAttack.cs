using UnityEngine;

public class DestroyerFormAttack : MonoBehaviour
{
    #region Class Variables
    [Header("Components")]
    [SerializeField] PlayerControllerAnimations m_playerControllerAnimations;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (m_playerControllerAnimations == null)
        {
            return;
        }

        if (Input.GetButton("FormAction"))
        {
            m_playerControllerAnimations.DestroyerAttack();
        }
    }
    #endregion
}
