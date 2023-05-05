using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject _sonZemin;
    private IEnumerator Start()
    {
        for (int i = 0; i < 10; i++)
        {
            ZeminOlustur();
            yield return new WaitForSeconds(.1f);
        }
    }
    void ZeminOlustur()
    {
        
        _sonZemin = Instantiate(_sonZemin, _sonZemin.transform.position + Vector3.back, transform.rotation, transform);
    }

}
