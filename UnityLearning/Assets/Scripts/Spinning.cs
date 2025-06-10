using UnityEngine;
using UnityEngine.UI;

public class Spinning : MonoBehaviour
{
    private bool rotatingRight = false;
    public Vector3 rotationSpeed;

    public Button myButton;
    public bool buttonPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myButton.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && rotatingRight==false || buttonPressed && rotatingRight==false)
            {
                rotationSpeed = new Vector3(0, -1000, 0);
                rotatingRight = true;
                buttonPressed = false;
            }
            
            else if (Input.GetKeyDown(KeyCode.Space) && rotatingRight==true || buttonPressed && rotatingRight==true) 
            {
                rotationSpeed = new Vector3(0, 1000, 0);
                rotatingRight = false;
                buttonPressed = false;
            }
    }

    public void ButtonClicked()
    {
        buttonPressed = true;
    }
    
}
