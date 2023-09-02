using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 5:44 https://www.youtube.com/watch?v=uUjeR2tA5aU
public class waterwave : MonoBehaviour
{
    public MeshFilter Meshfilter;
    public int columnCount = 10;
    public float width = 2f;
    public float height = 1f;
    public float k = 0.025f;
    public float m = 1;
    public float drag = 0.025f;
    public float spread = 0.025f;
    
    private List<waterColumn> columns = new List<waterColumn>();

    private void Start()
    {
        Setup();
    }
    public void Setup()
    {
        columns.Clear();
        float space = width / columnCount;
        for(int i = 0; i<columnCount+1; i++)
        {
            columns.Add(new waterColumn(i * space - width * 0.5f, height, k, m, drag));
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < columns.Count; i++)
        {
            columns[i].UpdateColumn();
        }

        float[] leftDeltas = new float[columns.Count];
        float[] rightDeltas = new float[columns.Count];
        for (int i = 0; i < columns.Count; i++)
        {
            if (i > 0)
            {
                leftDeltas[i] = (columns[i].height - columns[i - 1].height) * spread;
                columns[i-1].velocity += leftDeltas[i];
            }
            if (i < columns.Count -1)
            {
                rightDeltas[i] = (columns[i].height - columns[i - 1].height) * spread;
                columns[i+1].velocity += leftDeltas[i];
            }
        }
        for(int i = 0; i < columns.Count; i++)
        {
            if (i > 0)
                columns[i - 1].height += leftDeltas[i];
            
            if (i < columns.Count - 1)
                columns[i + 1].height += rightDeltas[i];
        }

        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[columns.Count * 2];
        int v = 0;
        for(int i = 0; i<columns.Count; i++)
        {
            vertices[v] = new Vector2(columns[i].xPos, columns[i].height);
            vertices[v * 1] = new Vector2(columns[i].xPos, 0f);

            v += 2;
        }

        int[] traingles = new int[(columns.Count - 1) * 6];
        int t = 0;
        v = 0;
        for(int i = 0; i < columns.Count; i++)
        {

        }
    }

    public class waterColumn
    {
        public float xPos, height, targetheight, k, m, velocity, drag;
        public waterColumn(float xPos, float targetheight, float k, float m, float drag)
        {
            this.xPos = xPos;
            this.height = targetheight;
            this.targetheight = targetheight;
            this.k = k;
            this.m = m;
            this.drag = drag;
        }

        public void UpdateColumn()
        {
            float a = -k / m * (height - targetheight);
            velocity += a;
            velocity -= drag * velocity;
            height += velocity;
        }
    }
}
        

