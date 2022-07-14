using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Transform Border;
    [SerializeField] private bool left;
    private Vector3[] startPositions;

    private void Awake()
    {
        startPositions = new Vector3[blocks.Length];
        for (int i = 0; i < blocks.Length; i++)
        {
            startPositions[i] = blocks[i].transform.position;
        }
    }

    private void Update()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].transform.position.x < Border.position.x && left)
            {
                blocks[i].transform.position = new Vector2(gameObject.transform.position.x, blocks[i].transform.position.y);
            }
            else if(blocks[i].transform.position.x > Border.position.x && !left)
            {
                blocks[i].transform.position = new Vector2(gameObject.transform.position.x, blocks[i].transform.position.y);
            }
        }
    }
}
