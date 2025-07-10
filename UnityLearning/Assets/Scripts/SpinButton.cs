using UnityEngine;

public class SpinButton : MonoBehaviour
{
    private Spinner targetSpinner;

    public void SetTargetSpinner(Spinner spinner)
    {
        targetSpinner = spinner;
    }

    public void OnButtonClick()
    {
        targetSpinner?.ReverseDirection();
    }
}
