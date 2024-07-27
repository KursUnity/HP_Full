using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    private void OnEnable() // �����������, ����� ������ ������������
    {
        Invoke(nameof(ObjectDeactivated), 10); // Invok - �����������. ���������� � nameof(�������� ������), ����� ������� ������ ��� �� ��������
    }

    private void ObjectDeactivated()
    {
        gameObject.SetActive(false);
    }
}
