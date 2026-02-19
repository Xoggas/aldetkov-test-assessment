using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class SfxPlayer : MonoBehaviourExtBind
{
    [SerializeField]
    private AudioClip _clickSfx;

    private AudioSource _audioSource;

    [OnAwake]
    private void OnAwake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    [Bind(Events.Scrolled)]
    private void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSfx);
    }
}
