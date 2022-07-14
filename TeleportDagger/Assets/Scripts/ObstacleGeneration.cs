using System.Collections;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] public GameObject[] obstacle;
    [SerializeField] public GameObject[] obstacleCenter;
    [SerializeField] private Transform LeftBorder;
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject[] coinPrefab;
    [SerializeField] private Hammer[] hammer;
    public bool FSP;
    private Vector3[] startPosition;
    private Vector3[] startPositionCenter;
    private int rand;
    private int randCoins;
    private bool isCooldown;

    enum TrackPos { Top = 1, Center = 0, Bottom = -1};
    enum CoinsStyle { Line, Jump}

    [SerializeField] private int coinsCountInItem = 10;
    float coinsHeight = -1;

    private void Start()
    {
        startPosition = new Vector3[obstacle.Length];
        startPositionCenter = new Vector3[obstacleCenter.Length];

        for(int i = 0; i < obstacle.Length; i++)
        {
            startPosition[i] = obstacle[i].transform.position;
        }

        for (int i = 0; i < obstacleCenter.Length; i++)
        {
            startPositionCenter[i] = obstacleCenter[i].transform.position;
        }
    }

    private void Update()
    {
         for(int i = 0; i < obstacle.Length; i++)
        {
            if(obstacle[i].transform.position.x < LeftBorder.position.x)
            {
                obstacle[i].transform.position = startPosition[i];
                obstacle[i].SetActive(false);
            }
        }
        for (int i = 0; i < obstacleCenter.Length; i++)
        {
            if (obstacleCenter[i].transform.position.x < LeftBorder.position.x)
            {
                obstacleCenter[i].transform.position = startPositionCenter[i];
                obstacleCenter[i].SetActive(false);
            }
        }
        AppearanceOfObjects();
    }

    public void ObstacleStartPosition()
    {
        for (int i = 0; i < obstacle.Length; i++)
        {
            obstacle[i].transform.position = startPosition[i];
            obstacle[i].SetActive(false);
        }
        for (int i = 0; i < obstacleCenter.Length; i++)
        {
            obstacleCenter[i].transform.position = startPositionCenter[i];
            obstacleCenter[i].SetActive(false);
        }
    }

    void AppearanceOfObjects()
    {
        if (!isCooldown)
        {
            rand = Random.Range(0, 100);
            if(rand > 20)
            {
                AppearanceOfObjectsTop();
                AppearanceOfObjectsBottom();
                StartCoroutine(Cooldown());
            }
            else
            {
                AppearanceOfObjectsCenter();
                StartCoroutine(Cooldown());
            }
        }
    }

    void AppearanceOfObjectsTop()
    {
        rand = Random.Range(0, obstacle.Length);
        if (obstacle[rand].activeInHierarchy == false)
        {
            randCoins = Random.Range(0, 100);
            obstacle[rand].SetActive(true);
            obstacle[rand].transform.Translate(obstacle[rand].transform.localPosition.x, (float)TrackPos.Top * 2.385f, 0);
            if(obstacle[rand].name == "NormalHammer")
            {
                hammer[rand].HammerMovement();
            }
            if(randCoins <= 80)
            {
                if (obstacle[rand].name == "BoxAndBigThorn")
                    CreateCoins(CoinsStyle.Jump, obstacle[rand].transform.position);
            }
            if(randCoins <= 30)
            {
                CreateCoins(CoinsStyle.Line, obstacle[rand].transform.position);
            }

        }
        else
        {
            AppearanceOfObjectsTop();
        }
    }

    void AppearanceOfObjectsBottom()
    {
        rand = Random.Range(0, obstacle.Length);
        if (obstacle[rand].activeInHierarchy == false)
        {
            randCoins = Random.Range(0, 100);
            obstacle[rand].SetActive(true);
            obstacle[rand].transform.Translate(obstacle[rand].transform.localPosition.x, (float)TrackPos.Bottom * 2.385f, 0);
            if (obstacle[rand].name == "NormalHammer")
            {
                hammer[rand].HammerMovement();
            }
            if (randCoins <= 80)
            {
                if(obstacle[rand].name == "BoxAndBigThorn")
                    CreateCoins(CoinsStyle.Jump, obstacle[rand].transform.position);
            }
            if (randCoins <= 30)
            {
                CreateCoins(CoinsStyle.Line, obstacle[rand].transform.position);
            }
        }
        else
        {
            AppearanceOfObjectsBottom();
        }
    }

    void AppearanceOfObjectsCenter()
    {
        rand = Random.Range(0, obstacleCenter.Length);
        if (obstacleCenter[rand].activeInHierarchy == false)
        {
            obstacleCenter[rand].SetActive(true);
            obstacleCenter[rand].transform.Translate(0, (float)TrackPos.Center, 0);
            if(obstacleCenter[rand].name == "FragileSolidAndPowerUp")
            {
                FSP = true;
            }
        }
        else
        {
            AppearanceOfObjects();
        }
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        yield break;
    }

    void CreateCoins(CoinsStyle style, Vector3 pos)
    {
        Vector3 coinPos = Vector3.zero;
        if(CoinsStyle.Line == style)
        {
            for(int i = -coinsCountInItem/2; i<(coinsCountInItem/2)-3; i++)
            {
                coinPos.y = coinsHeight;
                coinPos.x = i-3;
                for(int j = 0; j < coinPrefab.Length; j++)
                {
                    if(coinPrefab[j].activeInHierarchy == false)
                    {
                        coinPrefab[j].SetActive(true);
                        coinPrefab[j].transform.position = coinPos + pos;
                        break;
                    }
                }
            }
        }
        if(CoinsStyle.Jump == style)
        {
            for (int i = -coinsCountInItem / 2; i < (coinsCountInItem / 2)+1; i++)
            {
                coinPos.y = Mathf.Max(-1/5f * Mathf.Pow(i,2)+1, coinsHeight);
                coinPos.x = i;
                for (int j = 0; j < coinPrefab.Length; j++)
                {
                    if (coinPrefab[j].activeInHierarchy == false)
                    {
                        coinPrefab[j].SetActive(true);
                        coinPrefab[j].transform.position = coinPos + pos;
                        break;
                    }
                }
            }
         }
    }
}
