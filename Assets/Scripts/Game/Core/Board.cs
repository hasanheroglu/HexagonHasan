using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class Board : MonoBehaviour
    {   

        public GameObject CellPrefab;

        //Calculations depend on the arrangement of the hexagon tiles
        //Therefore variable is introduced to indicate that whether first column or second column is upper one.
        [Range(0,1)]
        public int IsSecondColumnUpper = 0;
        public int Rows;
        public int Cols;

        private Cell[,] _cells;

        // Start is called before the first frame update
        void Start()
        {
            _cells = new Cell[Rows, Cols];
            Fill();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void Fill()
        {
            float posX = 0;
            float posY = 0;

            for(int i=0; i<Rows; i++) 
            {
                for(int j=0; j<Cols; j++)
                {
                    if(j % 2 == IsSecondColumnUpper) 
                    {
                        posX = 1.5f * j;
                        posY = -((Mathf.Sqrt(3)) * i);
                    } 
                    else 
                    {
                        posX = 1.5f * j;
                        posY = -((Mathf.Sqrt(3)) * i + Mathf.Sqrt(3)/2);
                    }

                    var gameObject = Instantiate(CellPrefab, new Vector2(posX, posY), CellPrefab.transform.rotation, transform);
                    _cells[i, j] = gameObject.GetComponent<Cell>();
                    _cells[i, j].Prepare(j, i, posX, posY, this);
                }
            }
        }
    }
}


