using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public AudioClip _audioClip_Pig;
    public AudioClip _audioClip_Box;
    public AudioClip _audioClip_Emit;
    //public AudioSource _audioSource;
    // Use this for initialization
    void OnEnable() {
        //this._audioSource.PlayOneShot(_audioClip_Emit);
        if(this.gameObject.name != "BigBird") AudioSource.PlayClipAtPoint(_audioClip_Emit, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Pig")
        {
            //自行產生音樂 不受destory影響
            AudioSource.PlayClipAtPoint(_audioClip_Pig, transform.position);
        }
        else if (other.relativeVelocity.magnitude > 10) //反向作用力的向量轉成長度
        {
            //自行產生音樂 不受destory影響
            AudioSource.PlayClipAtPoint(_audioClip_Box, transform.position);
            //this._audioSource.PlayOneShot(_audioClip_Box);
        }
    }
}
