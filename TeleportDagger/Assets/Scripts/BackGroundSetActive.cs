using UnityEngine;

public class BackGroundSetActive : MonoBehaviour
{
    [SerializeField] private GameObject[] BackGroundName;

    private void Update()
    {
        for(int i = 0; i < BackGroundName.Length; i++)
        {
            if(i == Location.location)
            {
                BackGroundName[i].SetActive(true);
            }
            else
            {
                BackGroundName[i].SetActive(false);
            }
        }
    }
}
