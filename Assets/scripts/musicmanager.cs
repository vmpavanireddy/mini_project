using UnityEngine;

public class musicmanager : MonoBehaviour
{
    private static musicmanager instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
