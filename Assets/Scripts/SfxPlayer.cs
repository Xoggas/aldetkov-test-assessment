using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public sealed class SfxPlayer : MonoBehaviourExtBind
{
    [SerializeField]
    [FormerlySerializedAs("_clickSfx")]
    private AudioClip clickSfx;

    private AudioSource audioSource;

    [OnAwake]
    private void OnAwake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [Bind(Events.Scrolled)]
    private void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSfx);
    }
}
