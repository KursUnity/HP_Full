using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HPSlider;

    bool isHealing;
    bool isDangeros;

    private void Start()
    {
        HPSlider.value = HPSlider.maxValue;

        StartCoroutine(HPManager());
    }

    IEnumerator HPManager()
    {
        var timer = new WaitForSeconds(0.5f);

        while (true)
        {
            yield return timer;

            if (isHealing)
            {
                HPSlider.value += 0.1f;
            }

            if (isDangeros)
            {
                HPSlider.value -= 0.1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HPChanger(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        HPChanger(other, false);
    }

    private void HPChanger(Collider enemy, bool active)
    {
        if (enemy.gameObject.TryGetComponent(out Heal heal))
        {
            isHealing = active;
        }

        if (enemy.gameObject.TryGetComponent(out Danger danger))
        {
            isDangeros = active;
        }
    }
}
