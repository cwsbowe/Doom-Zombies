using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasebatAttack : MonoBehaviour {
    public bool attackBool;
    public float cooldown;
    public int damage;
    public AudioSource hitEnemy;
    public AudioSource hitWall;
    bool makeSound;
    // Start is called before the first frame update
    void Start() {
        attackBool = true;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            meleeAttack();
            print("attacking with bat");
        }
    }

    private void OnTriggerEnter(Collider other) {
        print("hit something" + other.tag);
        if (other.tag == "Enemy") {
            if (makeSound) {
                hitEnemy.Play();
                makeSound = false;
            }
            other.GetComponent<Health>().health -= damage;
            print("hit Enemy");
        } else if (other.tag != "Player" && makeSound) {
            hitWall.Play();
            makeSound = false;
        }
        
    }

    void meleeAttack() {
        if (attackBool) {
            attackBool = false;
            makeSound = true;
            GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine(ResetAttackCooldown());
        }
        
    }

    IEnumerator ResetAttackCooldown() {
        yield return new WaitForSeconds(cooldown);
        attackBool = true;
    }
}
