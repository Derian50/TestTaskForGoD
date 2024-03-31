using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float atackSpeed = 1f;
    [SerializeField] private GameObject[] dropLoot;
    private float _distanceToPlayer;
    private bool _isFollowingPlayer = false;
    [SerializeField] private float _followDistance = 5f;
    NavMeshAgent agent;

    private Transform _player;

    private bool _onCollisionWithPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = moveSpeed;
        _player = GameObject.FindGameObjectWithTag("Player").transform;

       
    }
    void Update()
    {
        
        _distanceToPlayer = Vector3.Distance(transform.position, _player.position);
        if (_distanceToPlayer <= _followDistance)
        {
            _isFollowingPlayer = true;
        }
        else
        {
            _isFollowingPlayer = false;
        }
        if (_player != null && _isFollowingPlayer)
        {
            Vector2 direction = _player.position - transform.position;

            direction.Normalize();
            agent.SetDestination(_player.position);
        }
        if (_player.position.x < transform.position.x)
        {
            // Игрок находится слева от врага, отражаем изображение по горизонтали
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // Игрок находится справа от врага, возвращаем изображение в исходное положение
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            _onCollisionWithPlayer = true;
            _player = other.transform;
            Invoke("tryTakeDamage", atackSpeed);
        }
    }
    private void tryTakeDamage()
    {
        if(_onCollisionWithPlayer)
        {
            _player.gameObject.GetComponent<Health>().TakeDamage(damage);
            Invoke("tryTakeDamage", atackSpeed);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            _onCollisionWithPlayer = false;
        }
    }
    public void DropLoot()
    {
        Instantiate(dropLoot[Random.Range(0, dropLoot.Length)], gameObject.transform.position, gameObject.transform.rotation);
    }
}