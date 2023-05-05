using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] List<Color> _colors;
    [SerializeField] Material _zeminMat;
    Color _ilkRenk, _ikinciRenk;
    int _birinciRenk;
    private void Start()
    {
        _birinciRenk = Random.Range(0, _colors.Count);
        _zeminMat.color = _colors[_birinciRenk];
        Camera.main.backgroundColor = _colors[_birinciRenk];
    }
    public void ChangingColor()
    {
        _birinciRenk = Random.Range(0, _colors.Count);
        _zeminMat.color = _colors[_birinciRenk];
        Camera.main.backgroundColor = _colors[_birinciRenk];
    }
}
