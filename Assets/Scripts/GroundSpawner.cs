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
    public void ZeminOlustur()
    {
        Vector3 yon;
        if (Random.Range(0,2) == 0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        _sonZemin = Instantiate(_sonZemin, _sonZemin.transform.position + yon, transform.rotation, transform);
    }

}
