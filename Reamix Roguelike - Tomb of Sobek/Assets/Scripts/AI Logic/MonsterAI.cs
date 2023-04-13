using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour {
    public string playerTag = "Player";
    public float attackDistance = 2f;
    public float damage = 10f;
    
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private GameObject _player;
    private bool _isAttacking;
    private IEnumerator _attackEnumerator;
    private static readonly int AttackHash = Animator.StringToHash("Attack");

    void Start() {
        _attackEnumerator = Attack();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindWithTag(playerTag);
        _isAttacking = false;
    }
    
    void Update() {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance < attackDistance && !_isAttacking) {
            StartCoroutine(_attackEnumerator);
        } else if (distance < _navMeshAgent.stoppingDistance) {
            _navMeshAgent.isStopped = true;
        } else {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }
    
    IEnumerator Attack() {
        _isAttacking = true;
        _animator.SetTrigger(AttackHash);
        yield return new WaitForSeconds(1f);
        if (Vector3.Distance(transform.position, _player.transform.position) < attackDistance) {
            _player.GetComponent<HealthManager>().TakeDamage(damage);
        }
        _isAttacking = false;
    }
}