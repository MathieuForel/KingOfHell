using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float x;
    [SerializeField] private float y;


    public IEnumerator Shake(float Duration, float Magnitude)
    {
        Debug.Log("IM SHAKING");

        Vector3 OriginalPosition = this.gameObject.transform.position;

        time = 0.0f;

        while (time < Duration * 0.2)
        {
            x = Random.Range(-1f, 1f) * Magnitude / 40;
            y = Random.Range(-1f, 1f) * Magnitude / 40;

            this.gameObject.transform.position = new Vector3(OriginalPosition.x + x, OriginalPosition.y + y, OriginalPosition.z);

            time += Time.deltaTime;

            yield return null;
        }

        this.gameObject.transform.position = OriginalPosition;
    }
}