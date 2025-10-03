using UnityEngine;

public class GlassJuiceAnimation : MonoBehaviour
{
    public GameObject glassBottle;
    public GameObject glassSplash;

    void DestroyGlass()
    {
        Instantiate(glassSplash, transform.position, Quaternion.identity);
        Destroy(glassBottle.gameObject);
    }
}
