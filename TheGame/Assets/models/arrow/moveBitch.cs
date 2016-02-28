using UnityEngine;
using System.Collections;

public class moveBitch : MonoBehaviour {

    Animator anim;
    int jumpHash = Animator.StringToHash("walk");
    int runStateHash = Animator.StringToHash("Base Layer.Run");


    void Start() {
        anim = GetComponent<Animator>();
    }


    void Update() {
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash) {
            anim.SetTrigger(jumpHash);
        }
    }
}
