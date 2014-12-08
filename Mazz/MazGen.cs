using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mazz
{
    public class MazGen
    {
        private static int _Rows;
        private static int _Columns;
        private static int _NodeWidth;

        private GridNode[,] _GridNodes = null;
        Stack<GridNode> _NodeStack = new Stack<GridNode>();
        GridNode _CurrentNode = null;

        private int _VisitedNodes = 1;
        private int _TotalNodes;

        public MazGen(int Row, int Columns, int NodeWidth)
        {
            _Rows = Row;
            _Columns = Columns;
            _NodeWidth = NodeWidth;
            _TotalNodes = _Rows * _Columns;
            InitializeGrid();
            GeneratePaths();
        }

        public static int Rows { get { return _Rows; } }
        public static int Columns { get { return _Columns; } }
        public static int NodeWidth { get { return _NodeWidth; } }

        private void InitializeGrid()
        {
            _GridNodes = new GridNode[_Rows, _Columns];
            for (int x = 0; x < _Rows; x++)
                for (int y = 0; y < _Columns; y++)
                {
                    _GridNodes[x, y] = new GridNode();
                    _GridNodes[x, y].Row = x;
                    _GridNodes[x, y].Column = y;
                }
            _CurrentNode = _GridNodes[0, 0];
            _VisitedNodes = 1;
            _NodeStack.Clear();
        }

        private void GeneratePaths()
        {
            while (_VisitedNodes < _TotalNodes)
            {
                List<GridNode> _AdjacentCells = GetNeighbors(_CurrentNode);
                if (_AdjacentCells.Count > 0)
                {
                    int _RandomNode = GridNode._Random.Next(0, _AdjacentCells.Count);
                    GridNode _Node = _AdjacentCells[_RandomNode];
                    _CurrentNode.RemoveWall(_Node);
                    _NodeStack.Push(_CurrentNode);
                    _CurrentNode = _Node;
                    _VisitedNodes++;
                }
                else _CurrentNode = _NodeStack.Pop();
            }
        }

        private List<GridNode> GetNeighbors(GridNode Node)
        {

            List<GridNode> _Neighbors = new List<GridNode>();
            for (int x = -1; x <= 1; x++)
                for (int y = -1; y <= 1; y++)
                {
                    if (Node.Row + x < _Rows && Node.Column + y < _Columns && Node.Row + x >= 0 &&
                        Node.Column + y >= 0 && (x == 0 || y == 0) && x != y)
                    {
                        if (_GridNodes[Node.Row + x, Node.Column + y].AllWallsUp())
                            _Neighbors.Add(_GridNodes[Node.Row + x, Node.Column + y]);
                    }
                }

            return _Neighbors;
        }

        public void Draw(Graphics _Graphics)
        {
            for (int x = 0; x < _Rows; x++)
                for (int y = 0; y < _Columns; y++)
                    _GridNodes[x, y].Draw(_Graphics);
        }
    }
}
