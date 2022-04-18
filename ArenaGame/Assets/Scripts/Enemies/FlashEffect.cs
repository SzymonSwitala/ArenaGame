using System.Collections;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    private Material defaultMaterial;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Coroutine flashRoutine;
    [SerializeField] float duration;
    void Start()
    {
     
        defaultMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = defaultMaterial;

    }
}
