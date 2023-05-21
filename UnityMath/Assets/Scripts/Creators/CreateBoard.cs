using System;
using UnityEngine;
using UnityEngine.UI;

namespace Creators
{
    public class CreateBoard : MonoBehaviour
    {
        public GameObject[] tilePrefabs;
        public GameObject housePrefab;
        public GameObject treePrefab;
        public Text score;
        private long _dirtBb = 0;
        private long _desertBb = 0;
        private long _treeBb = 0;
        private long _playerBb = 0;
        private GameObject[] _tiles;
    
        // Start is called before the first frame update
        void Start()
        {
            _tiles = new GameObject[64];
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                    Vector3 pos = new Vector3(c, 0, r);
                    GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                    tile.name = $"{tile.tag}_{r}_{c}";
                    _tiles[r * 8 + c] = tile;
                    if (tile.CompareTag($"Dirt"))
                    {
                        _dirtBb = SetCellState(_dirtBb, r, c);
                        PrintBB("Dirt", _dirtBb);
                    }

                    if (tile.CompareTag($"Desert"))
                    {
                        _desertBb = SetCellState(_desertBb, r, c);
                        PrintBB("Desert", _desertBb);
                    }
                }
            }

            Debug.Log("Dirt cells = " + CellCount(_dirtBb));
            InvokeRepeating("PlantTree", 1, 1);
        }

        void PlantTree()
        {
            int rr = UnityEngine.Random.Range(0, 8);
            int rc = UnityEngine.Random.Range(0, 8);
            if (GetCellState(_dirtBb & ~_playerBb, rr, rc))
            {
                GameObject tree = Instantiate(treePrefab, _tiles[rr * 8 + rc].transform, true);
                tree.transform.localPosition = Vector3.zero;
                _treeBb = SetCellState(_treeBb, rr, rc);
            }
        }

        void CalculateScore()
        {
            score.text = $"Score: {CellCount(_dirtBb & _playerBb) * 10 + CellCount(_desertBb & _playerBb) * 2}";
        }

        void PrintBB(string name, long bb)
        {
            Debug.Log($"{name}: {Convert.ToString(bb, 2).PadLeft(64, '0')}");
        }

        long SetCellState(long bitboard, int row, int col)
        {
            long newBit = 1L << (row * 8 + col);
            return bitboard |= newBit;
        }

        bool GetCellState(long bitboard, int row, int col)
        {
            long mask = 1L << (row * 8 + col);
            return ((bitboard & mask) != 0);
        }

        int CellCount(long bitboard)
        {
            int count = 0;
            long bb = bitboard;
            while (bb != 0)
            {
                bb &= bb - 1;
                count++;
            }

            return count;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Camera.main is { })
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        var o = hit.collider.gameObject;
                        var position = o.transform.position;
                        var r = (int)position.z;
                        var c = (int)position.x;
                        if (GetCellState((_dirtBb & ~_treeBb) | _desertBb, r, c))
                        {
                            GameObject house = Instantiate(housePrefab, hit.collider.gameObject.transform, true);
                            house.transform.localPosition = Vector3.zero;
                            _playerBb = SetCellState(_playerBb, r, c);
                            CalculateScore();
                        }
                    }
                }
            }
        }
    }
}
