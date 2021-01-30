using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class Cell : MonoBehaviour
    {
        [HideInInspector] public int X;
        [HideInInspector] public int Y;

        [HideInInspector] public float PosX;
        [HideInInspector] public float PosY;

        public float HexagonUnit = 1.0f;
        public Board Board;


        private Dictionary<Corner, Vector2> _hexagonCorners;

        // Start is called before the first frame update
        void Awake()
        {
            _hexagonCorners = new Dictionary<Corner, Vector2>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Prepare(int x, int y, float posX, float posY, Board board)
        {
            X = x;
            Y = y;
            PosX = posX;
            PosY = posY;
            Board = board;
            _hexagonCorners.Add(Corner.TopLeft, new Vector2(PosX - HexagonUnit*0.5f, PosY + HexagonUnit*Mathf.Sqrt(3)/2));
            _hexagonCorners.Add(Corner.TopRight, new Vector2(PosX + HexagonUnit*0.5f, PosY + HexagonUnit*Mathf.Sqrt(3)/2));
            _hexagonCorners.Add(Corner.Right, new Vector2(PosX + HexagonUnit*1.0f, PosY));
            _hexagonCorners.Add(Corner.BottomRight, new Vector2(PosX + HexagonUnit*0.5f, PosY - HexagonUnit*Mathf.Sqrt(3)/2));
            _hexagonCorners.Add(Corner.BottomLeft, new Vector2(PosX - HexagonUnit*0.5f, PosY - HexagonUnit*Mathf.Sqrt(3)/2));
            _hexagonCorners.Add(Corner.Left, new Vector2(PosX - HexagonUnit*1.0f, PosY));
        }

        public KeyValuePair<Corner, Vector2> GetClosestGroupPoint(Vector2 position)
        {
            float smallestDistance = Mathf.Infinity;
            KeyValuePair<Corner, Vector2> closestCorner;
            foreach(var corner in _hexagonCorners)
            {
                if (!IsGroupPointOutOfBounds(corner.Key)) 
                {
                    continue;
                }

                float distance = Vector2.Distance(position, corner.Value);

                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    closestCorner = corner;
                }
            }

            Debug.Log(closestCorner.Key);
            return closestCorner;
        }

        

        
        public bool IsGroupPointOutOfBounds(Corner corner)
        {
            if (X == 0 && Y == 0) 
            {
                if (X % 2 == Board.IsSecondColumnUpper)
                {
                    return corner == Corner.BottomRight;
                }
                else
                {
                    return corner == Corner.BottomRight || corner == Corner.Right;
                }
            }

            if (X == 0 && Y == Board.Rows - 1) 
            {
                if (X % 2 == Board.IsSecondColumnUpper)
                {
                    return corner == Corner.TopRight || corner == Corner.Right;
                }
                else
                {
                    return corner == Corner.TopRight;
                }
            }

            if (X == Board.Cols - 1 && Y == 0) 
            {
                if (X % 2 == Board.IsSecondColumnUpper)
                {
                    return corner == Corner.BottomLeft;
                }
                else
                {
                    return corner == Corner.Left || corner == Corner.BottomLeft;
                }
            }

            if (X == Board.Cols - 1 && Y == Board.Rows - 1) 
            {
                if (X % 2 == Board.IsSecondColumnUpper)
                {
                    return corner == Corner.TopLeft || corner == Corner.Left;
                }
                else
                {
                    return corner == Corner.Left;
                }
            }

            if (X == 0) 
            {
                return corner == Corner.BottomRight || corner == Corner.Right || corner == Corner.TopRight;
            }

            if (X == Board.Cols - 1) 
            {
                return corner == Corner.BottomLeft || corner == Corner.Left || corner == Corner.TopLeft;
            }

            if (Y == 0) 
            {  
                if (X % 2 == Board.IsSecondColumnUpper)
                {
                    return corner == Corner.BottomLeft || corner == Corner.BottomRight;
                }
                else
                {
                    return corner == Corner.Left || corner == Corner.BottomLeft || corner == Corner.BottomRight || corner == Corner.Right;
                }
            }

            if (Y == Board.Rows - 1) 
            {  
                if (X % 2 == Board.IsSecondColumnUpper)
                {
                    return corner == Corner.TopLeft || corner == Corner.TopRight;
                }
                else
                {
                    return corner == Corner.Left || corner == Corner.TopLeft || corner == Corner.TopRight || corner == Corner.Right;
                }
            }

            return true;
        }
        
        public void CreateGroup()
        {

        }
    }

}
