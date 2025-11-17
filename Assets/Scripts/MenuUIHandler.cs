using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject PlayerNameContainer;
    public GameObject StartContainer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerNameContainer.SetActive(true);
        StartContainer.SetActive(false);
    }
}
