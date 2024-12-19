using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Calculate damping factor (linearly reduces intensity over time)
            float dampingFactor = 1f - (elapsed / duration);

            // Apply random offset with damping
            float x = Random.Range(-1f, 1f) * magnitude * dampingFactor;
            float y = Random.Range(-1f, 1f) * magnitude * dampingFactor;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Reset camera position to the original
        transform.localPosition = originalPosition;
    }
}
