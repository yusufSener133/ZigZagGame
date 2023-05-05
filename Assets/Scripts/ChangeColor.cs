using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] List<Color> _colors;
    [SerializeField] Material _zeminMat;
    Color _renk;
    int _birinciRenkIndex;
    private void Start()
    {
        _birinciRenkIndex = Random.Range(0, _colors.Count);
        _renk = _colors[IkinciRenkSec()];
        _zeminMat.color = _colors[_birinciRenkIndex];
        Camera.main.backgroundColor = _colors[_birinciRenkIndex];
    }
    private void Update()
    {
        Color fark = _zeminMat.color - _renk;
        if (Mathf.Abs(fark.r)+ Mathf.Abs(fark.g) + Mathf.Abs(fark.b) <0.2f)
        {
            _renk = _colors[IkinciRenkSec()];
        }
        _zeminMat.color = Color.Lerp(_zeminMat.color,_renk,0.003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, _renk, 0.0007f);
    }
    int IkinciRenkSec()
    {
        int ikinciRenkIndex;
        ikinciRenkIndex = Random.Range(0, _colors.Count);
        while (ikinciRenkIndex == _birinciRenkIndex)
        {
            ikinciRenkIndex = Random.Range(0, _colors.Count);
        }
        return ikinciRenkIndex;
    }
    
    /*
    .BestScore StartPanelde
    .Font değiştir
    .Buton resimleri değiştir
    .Score işlemini değiştir (altın topla)
    .Score 30 un katı olduğunda oyun hızlansın
    .*Paneller animasyonla gelsin
    .BestScore değiştiyse animasyonlu bişiler
     */
}
