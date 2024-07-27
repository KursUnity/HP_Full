using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform Turrel;
    public Bullet BulletPrefab;
    List<Bullet> Bullets = new List<Bullet>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryGetEmptyBullet();
        }
    }

    private void TryGetEmptyBullet()
    {
        if (Bullets.Any()) // Если в списке пуль есть хотя бы одна пуля
        {
            foreach (Bullet bullet in Bullets)
            {
                if (!bullet.gameObject.activeSelf) // Если из списка патрон, есть неактивный патрон
                {
                    bullet.gameObject.SetActive(true);
                    bullet.transform.position = Turrel.position;
                    bullet.transform.rotation = Turrel.rotation;
                    return; // Остановить метод, если нашли и активировали пулю
                }
            }
        }

        Bullet prefab = Instantiate(BulletPrefab, Turrel.position, Turrel.rotation);
        Bullets.Add(prefab); // Добавляем в ЛИСТ созданную пулю
    }
}
