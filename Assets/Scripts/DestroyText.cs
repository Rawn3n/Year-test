using UnityEngine;

public class DestroyText : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(0, 1, 0);
    public Vector3 Randomize = new Vector3(0.5f, 0 ,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, DestroyTime);

        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-Randomize.x, Randomize.y), Random.Range(-Randomize.y, Randomize.x));    
    }
}
