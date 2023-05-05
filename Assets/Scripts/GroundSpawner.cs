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
            yon = new Vector3(-1,5,0);
            //yon = Vector3.left;
        }
        else
        {
            yon = new Vector3(0,5,-1);
            //yon = Vector3.back;
        }
        Vector3 yonUp = _sonZemin.transform.position + yon;
        Vector3 yonDown = new Vector3(yonUp.x, 0, yonUp.z);
        _sonZemin = Instantiate(_sonZemin, Vector3.Lerp(yonUp,yonDown,1), transform.rotation, transform);
    }

}
