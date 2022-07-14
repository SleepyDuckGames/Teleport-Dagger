using UnityEngine;

public class FragileSolidAndPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject solidLump;
    [SerializeField] private GameObject fragileLump;
    [SerializeField] private GameObject fragileLumpMain;
    [SerializeField] private ObstacleGeneration obstacleGeneration;
    [SerializeField] private FragileLump FragileLump;
    [SerializeField] private GameObject pieces;

    private float rand;
    

    private void Update()
    {
        if(obstacleGeneration.FSP == true)
        {
            Pos();
        }

    }

    public void Pos()
    {
        rand = Random.Range(0, 100);
        if(rand > 50)
        {
            powerUp.SetActive(true);
            powerUp.transform.localPosition = new Vector3(-6, 1, 0);
        }
        else
        {
            powerUp.SetActive(true);
            powerUp.transform.localPosition = new Vector3(-6, -3.5f, 0);
        }
        rand = Random.Range(0, 100);
        if (rand > 50)
        {
            solidLump.SetActive(true);
            fragileLump.SetActive(true);
            solidLump.transform.localPosition = new Vector3(0, 2.3f, 0);
            fragileLumpMain.transform.localPosition = new Vector3(0, -2.5f, 0);
            FragileLump.Cooldown();

        }
        else
        {
            solidLump.SetActive(true);
            fragileLump.SetActive(true);
            solidLump.transform.localPosition = new Vector3(0, -2.5f, 0);
            fragileLumpMain.transform.localPosition = new Vector3(0, 2.3f, 0);
            FragileLump.Cooldown();
        }
        obstacleGeneration.FSP = false;
    }
}
