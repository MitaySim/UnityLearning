using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpinnerManager : MonoBehaviour
{
    public GameObject spinnerPrefab; //poochacho
    public GameObject buttonPrefab;//spinbutton
    public Transform buttonParent;//horizontalpaneloverlay
    public Transform spinnerSpawnPoint; //spawn

    private List<Spinner> allSpinners = new List<Spinner>();
    private List<GameObject> allButtons = new List<GameObject>();

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space action
        {
            foreach (var spinner in allSpinners)
            {
                if (spinner != null)
                    spinner.ReverseDirection();
            }
        }
    }

    public void AddSpinner() // Press button add poochie
    {
        Vector3 spawnPosition = spinnerSpawnPoint.position + GetRandomOffset();
        GameObject newSpinner = Instantiate(spinnerPrefab, spawnPosition, Quaternion.identity);
        newSpinner.name = "Spinner_" + Random.Range(0, 7);

        Spinner spinnerScript = newSpinner.GetComponent<Spinner>();
        allSpinners.Add(spinnerScript);
        
        AddButton(spinnerScript); //now separated as its ow function
  
    }
public void AddButton(Spinner targetSpinner)//Add the poochie spin inversion button
{
        GameObject newButton = Instantiate(buttonPrefab, buttonParent); //create a button from the prefab into the horizontal view
        SpinButton spinButton = newButton.GetComponent<SpinButton>(); 
        spinButton.SetTargetSpinner(targetSpinner);

        allButtons.Add(newButton);
} 

    public void DeleteButton() // Call this to delete all poochies and buttons
    {
        // Destroy all spinner GameObjects
        foreach (var spinner in allSpinners)
        {
            if (spinner != null)
                Destroy(spinner.gameObject);
        }
        allSpinners.Clear();

        // Destroy all button GameObjects
        foreach (var button in allButtons)
        {
            if (button != null)
                Destroy(button);
        }
        allButtons.Clear();
    }

    Vector3 GetRandomOffset()
    {
        float offsetX = Random.Range(-3f, 3f);
        float offsetZ = Random.Range(-3f, 3f);
        return new Vector3(offsetX, 0f, offsetZ);
    }
}
