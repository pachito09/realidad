using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject currObject = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void CreateObjects(GameObject obj)
    {
        if (currObject != null)
        {
            DestroyObject(currObject);
        }
        currObject = Instantiate(obj, Vector3.zero, Quaternion.identity);
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
