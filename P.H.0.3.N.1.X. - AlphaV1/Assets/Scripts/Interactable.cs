using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Form requiredForm = Form.Manipulator;

    public void Interact(Form currForm)
    {
        if (currForm != requiredForm)
            return;

        Destroy(this.gameObject);
    }
}
