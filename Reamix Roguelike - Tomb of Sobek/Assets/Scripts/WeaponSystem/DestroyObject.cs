using UnityEngine;


public class DestroyObject : MonoBehaviour
{
    [SerializeField] private int cubesPerAxis = 8;
    [SerializeField] private float force = 300f;
    [SerializeField] private float radius = 2f;


    public void Main()
    {
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                {
                    CreateCubes(new Vector3(x, y, z));
                }
            }
        }
        Destroy(gameObject);
    }

    public void CreateCubes(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rd = cube.GetComponent<Renderer>();
        //rd.material.color = new Color(coordinates.x / cubesPerAxis, coordinates.y / cubesPerAxis, coordinates.z / cubesPerAxis);
        rd.material = GetComponent<Renderer>().material;
        cube.transform.localScale = transform.localScale / cubesPerAxis;
        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);
        var destroy_time = Random.Range(0.1f, 1.0f);

        Destroy(cube, destroy_time);
    }

}



