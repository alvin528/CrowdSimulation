﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace testAstar
{
    public class AstarNode { private AstarNode parent = null; private int g; private int h; private int x; private int y; public AstarNode Parent { get { return parent; } set { parent = value; } } public int G { get { return g; } set { g = value; } } public int H { get { return h; } set { h = value; } } public int F { get { return g + h; } } public int X { get { return x; } set { x = value; } } public int Y { get { return y; } set { y = value; } } public AstarNode(int _x, int _y) { this.x = _x; this.y = _y; this.parent = null; this.g = 0; this.h = 0; } }
    public class Astar
    {
        private List<AstarNode> openList = new List<AstarNode>(); private List<AstarNode> closeList = new List<AstarNode>(); private bool[,] mapData = null; private int pixelFormat = 16; private int mapWidth = 0; private int mapHeight = 0; private int endX = 0; private int endY = 0; public bool[,] MapData { get { return mapData; } }
        public int PixelFormat { get { return pixelFormat; } }
        public int MapWidth { get { return mapWidth; } }
        public int MapHeight { get { return mapHeight; } }
        public Astar() { }
        private bool isValid(int x, int y) { if (x < 0 || x >= mapWidth) { return false; } if (y < 0 || y >= mapHeight) { return false; } return true; }
        private bool inList(List<AstarNode> list, int x, int y) { foreach (AstarNode node in list) { if (node.X == x && node.Y == y) { return true; } } return false; }
        private bool inOpenList(int x, int y) { return inList(openList, x, y); }
        private bool inCloseList(int x, int y) { return inList(closeList, x, y); }
        private AstarNode getBestNodeFromOpenList() { if (openList.Count == 0) { return null; } return openList[0]; }
        private void openToClose(AstarNode node) { openList.Remove(node); closeList.Add(node); }
        private AstarNode openToCloseWithBest() { AstarNode node = getBestNodeFromOpenList(); if (node == null) { return null; } openToClose(node); return node; }
        private void addToOpenList(AstarNode parent, int x, int y) { if (!isValid(x, y)) { return; } if (inOpenList(x, y) || inCloseList(x, y)) { return; } if (!canWalk(x, y) && parent != null) { return; } AstarNode node = new AstarNode(x, y); node.Parent = parent; if (parent == null) { node.G = 0; node.H = 0; } else { if (Math.Abs(parent.X - x) + Math.Abs(parent.Y - y) == 2) { node.G = 14; } else { node.G = 10; } node.H = Math.Abs(endX - x) * 10 + Math.Abs(endY - y) * 10; } openList.Add(node); openList.Sort(delegate (AstarNode lhs, AstarNode rhs) { if (lhs.F < rhs.F) { return -1; } else if (lhs.F > rhs.F) { return 1; } return 0; }); }
        private void genAroundNode(AstarNode node)
        {            //addToOpenList(node, node.X - 1, node.Y - 1);            addToOpenList(node, node.X - 1, node.Y);            //addToOpenList(node, node.X - 1, node.Y + 1);             addToOpenList(node, node.X, node.Y - 1);            addToOpenList(node, node.X, node.Y + 1);             //addToOpenList(node, node.X + 1, node.Y - 1);            addToOpenList(node, node.X + 1, node.Y);            //addToOpenList(node, node.X + 1, node.Y + 1);        }         private AstarNode findNearPointFromList(List<AstarNode> list, int x, int y)        {            AstarNode result = null;            int minDistance = int.MaxValue;             foreach (AstarNode node in list)            {                int dist = (int)Math.Sqrt(Math.Abs(node.X - x) * Math.Abs(node.X - x) + Math.Abs(node.Y - y) * Math.Abs(node.Y - y));                 if (dist < minDistance)                {                    minDistance = dist;                    result = node;                }            }             return result;        }         public bool canWalk(int x, int y)        {            return mapData[x, y];        }         public bool canWalkPixel(int x, int y)        {            int px = x / pixelFormat;            int py = y / pixelFormat;             return canWalk(px, py);        }         public List<AstarNode> findPath(int _startX, int _startY, int _endX, int _endY)        {            this.endX = _endX;            this.endY = _endY;            this.openList.Clear();            this.closeList.Clear();            List<AstarNode> result = new List<AstarNode>();            AstarNode currNode = null;            bool findPathFlag = false;             addToOpenList(null, _startX, _startY);             while (openList.Count > 0)            {                currNode = openToCloseWithBest();                 if (currNode == null)                {                    break;                }                 if (currNode.X == _endX && currNode.Y == _endY)                {                    findPathFlag = true;                    break;                }                 genAroundNode(currNode);            }             if (!findPathFlag)            {                currNode = findNearPointFromList(closeList, endX, endY);            }             if (currNode == null)            {                return null;            }             while (true)            {                result.Add(currNode);                 if (currNode.X == _startX && currNode.Y == _startY)                {                    break;                }                 currNode = currNode.Parent;            }             result.Reverse();             return result;        }         public List<AstarNode> findPathPixel(int startX, int startY, int endX, int endY)        {            int sx = startX / pixelFormat;            int sy = startY / pixelFormat;            int ex = endX / pixelFormat;            int ey = endY / pixelFormat;             List<AstarNode> result = findPath(sx, sy, ex, ey);             if (result == null)            {                return null;            }             for (int i = 0; i < result.Count; ++i)            {                result[i].X *= pixelFormat;                result[i].Y *= pixelFormat;            }             return result;        }         public void enableMapData(int x, int y, bool value)        {            mapData[x, y] = value;        }         public void enableMapDataPixel(int x, int y, bool value)        {            int px = x / pixelFormat;            int py = y / pixelFormat;             enableMapData(px, py, value);        }         public void syncMapData(int x, int y)        {            mapData[x, y] = !mapData[x, y];        }         public void syncMapDataPixel(int x, int y)        {            int px = x / pixelFormat;            int py = y / pixelFormat;             syncMapData(px, py);        }         public void enableMapDataAll(bool value)        {            for (int w = 0; w < mapWidth; ++w)            {                for (int h = 0; h < mapHeight; ++h)                {                    mapData[w, h] = value;                }            }        }         public void initMapData(int _widthPixel, int _heightPixel, int _pixelFormat)        {            int width = _widthPixel / _pixelFormat;            int height = _heightPixel / _pixelFormat;             pixelFormat = _pixelFormat;            mapData = new bool[width, height];            mapWidth = width;            mapHeight = height;             enableMapDataAll(true);        }    }}