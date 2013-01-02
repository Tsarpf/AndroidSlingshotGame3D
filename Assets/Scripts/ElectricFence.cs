using UnityEngine;
using System.Collections;

public class ElectricFence : MonoBehaviour
{
    public Color c1 = Color.blue;
    public Color c2 = Color.white;
    int lengthOfLineRenderer = 0;

    GameObject pole1;
    GameObject pole2;
    void Start()
    {
        //Find the poles to which the 'fence' is 'attached' to
        pole1 = getChildObjectByName("Pole1");
        pole2 = getChildObjectByName("Pole2");
        float distance = Vector3.Distance(pole1.transform.position, pole2.transform.position);
        lengthOfLineRenderer = (int)distance;

        //Initialize the linerenderer
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);

        setCollider(distance);
    }
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        int i = 0;
        while (i < lengthOfLineRenderer)
        {
            
            float x;
            float z;
            if (i == 0)
            {
                x = pole1.transform.position.x;
                z = pole1.transform.position.z;
            }
            else if(i == lengthOfLineRenderer - 1)
            {
                x = pole2.transform.position.x;
                z = pole2.transform.position.z;
            }
            else
            {
                //Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
                x = (((pole1.transform.position.x - pole2.transform.position.x) / lengthOfLineRenderer) *
                -i) + pole1.transform.position.x;

                z = (((pole1.transform.position.z - pole2.transform.position.z) / lengthOfLineRenderer) *
                -i) + pole1.transform.position.z;
            }
            
            Vector3 pos = new Vector3(x, Mathf.Sin(i + Time.time) + 3, z);
             

            lineRenderer.SetPosition(i, pos);
            i++;
        }
    }
    int point = 0;
    private Vector3 getPosAlternativeLookXDEBIN(int i)
    {
        float x;
        float z;
        if (i == 0)
        {
            x = pole1.transform.position.x;
            z = pole1.transform.position.z;
        }
        else if (i == lengthOfLineRenderer - 1)
        {
            x = pole2.transform.position.x;
            z = pole2.transform.position.z;
        }
        else
        {
            //Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
            x = (((pole1.transform.position.x - pole2.transform.position.x) / lengthOfLineRenderer) *
            -i) + pole1.transform.position.x;

            z = (((pole1.transform.position.z - pole2.transform.position.z) / lengthOfLineRenderer) *
            -i) + pole1.transform.position.z;
        }

        if (i == point)
        {
            return new Vector3(x, Mathf.Sin(i + Time.time) + 3, z);
        }
        point++;
        return new Vector3(x, Mathf.Sin(i + Time.time) + 3, z);
    }

    void setCollider(float length)
    {
        GameObject colliderGO = getChildObjectByName("Collider");
        CapsuleCollider collider = colliderGO.AddComponent<CapsuleCollider>();

        collider.height = length;
        collider.transform.position = new Vector3(
                                          (pole1.transform.position.x + pole2.transform.position.x) / 2,
                                          pole1.transform.position.y + 1,
                                          (pole1.transform.position.z + pole2.transform.position.z) / 2
                                          );

        Vector3 dir = (pole2.transform.position - pole1.transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z);
        angle *= Mathf.Rad2Deg;
        collider.transform.rotation = Quaternion.Euler(new Vector3(0, angle - 90, 90));
        collider.isTrigger = true;                                    
    }

    /// <summary>
    /// Returns the first child gameobject to have the supplied name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private GameObject getChildObjectByName(string name)
    {
        foreach (Transform kid in gameObject.transform)
        {
            if(kid.gameObject.name == name)
                return kid.gameObject;
        }
        return null;
    }

    //Vector3(to - from).normalized; = direction
}