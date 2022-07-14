using UnityEngine;

public class RepeatMover : MonoBehaviour
{
    public Transform[] blocks;
    public Vector3 axis;
    public float tileSize;
    public bool startPosition;
    private Vector3 _start;
    private int[] _cid;
    private float _pre = 0f;
    private int j = 0;

    void Awake()
    {
        _start = blocks[0].position;
        _cid = new int[blocks.Length];
        for (int i = 0; i < blocks.Length; ++i)
            _cid[i] = i;
    }

    void Update()
    {
        float re = Mathf.Repeat(Time.time * Speed.speed, tileSize);
        bool over = (re < _pre);
        _pre = re;
        for (int i = 0; i < blocks.Length; ++i)
        {
            if (over)
            {
                if (_cid[i] == _cid[_cid.Length - 1])
                {
                    if(j == blocks.Length)
                    {
                        j = 0;
                        startPosition = true;
                    }
                    j++;
                }
                _cid[i] = (_cid[i] + 1) % _cid.Length;
            }
            blocks[i].position = _start + (axis * _cid[i] * tileSize) + (axis * re);
        }
    }
}
