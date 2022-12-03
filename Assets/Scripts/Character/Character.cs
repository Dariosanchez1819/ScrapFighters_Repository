using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Character : MonoBehaviour
{

	/*
	**		Components
	*/

	private Rigidbody2D		rb;
	private Transform		tr;
	private Animator		an;






	/*
	**		Player Variables
	*/

	[Space(20)]
	[Header("Player:")]


	public char				player;






	/*
	**      Horizontal Mov Variables
	*/

	public int				lives;
	public int				shields;
	private int				shields_max;






	/*
	**      Horizontal Mov Variables
	*/

	[Space(20)]
	[Header("Movement:")]


	public float			speed;
	private float			moveInput;






	/*
	**      Jump Variables
	*/
	
	[Space(20)]
	[Header("Jump:")]


	public Transform		feet_pos;
	public bool				is_grounded;
	public LayerMask		ground_mask;
	private float			check_radius;

	public float			jump_force;
	private float			og_jump_force;
	public float			second_jump_force;
	
	private int				n_jumps;
	private float			max_jump_timer;
	public float			max_jump_cooldown = 1.5f;






	/*
	**      Attack Variables
	*/
	
	[Space(20)]
	[Header("Attack:")]


	public bool				attacking;
	public float			attack_cooldown;
	public float			attack_time_max;

	private bool			attack_key;






	/*
	**      KnockBack Variables
	*/

	[Space(20)]
	[Header("Knockback:")]


	public float			Knockback_strenght;
	public float			delay = 0.15f;
	private bool			knockback_bool = false;

	public	float			knockback_time;
	public	float			ultimate_now;
	public	float			ultimate_max;
	
	private	bool			ultimate_hitted;






	/*
	**      UI  Variables
	*/

	[Space(20)]
	[Header("UI:")]


	public Character			opponent;
	public TextMeshProUGUI		text_life;
	public TextMeshProUGUI		text_shield;
	public TextMeshProUGUI		text_ulti;






	/*
	**		  .oooooo.                                          
	**		 d8P'  `Y8b                                         
	**		888            .oooo.   ooo. .oo.  .oo.    .ooooo.  
	**		888           `P  )88b  `888P"Y88bP"Y88b  d88' `88b 
	**		888     ooooo  .oP"888   888   888   888  888ooo888 
	**		`88.    .88'  d8(  888   888   888   888  888    .o 
	**		 `Y8bood8P'   `Y888""8o o888o o888o o888o `Y8bod8P' 
	*/                                                
													
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<Transform>();
		an = GetComponent<Animator>();

		ultimate_now = 0;
		
		attack_key = true;
		ultimate_hitted = false;

		shields_max = shields;
		og_jump_force = jump_force;

		text_life.text = lives.ToString();
		text_shield.text = shields.ToString();
		text_ulti.text = ultimate_now.ToString();
	}

	void Update()
	{
		jump();
		moving_direction();
	}

	void FixedUpdate()
	{
		ft_attack();
		h_mov();
		text_ulti.text = ultimate_now.ToString();
	}








	/*
	**		Horizontal Mov
	*/

	int		h_mov()
	{
		if (attacking == true)
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
			return (1);
		}

		if (player == 'a')
			moveInput = Input.GetAxisRaw("Horizontal_a");		//Less slippery
		else if (player == 'b')
			moveInput = Input.GetAxisRaw("Horizontal_b");		//Less slippery

		if (knockback_bool == false)
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		return (0);
	}

	void	moving_direction()
	{
		if (moveInput > 0)
			tr.eulerAngles = new Vector3(0, 0, 0);
		if (moveInput < 0)
			tr.eulerAngles = new Vector3(0, 180, 0);
	}






	/*
	**		Jump
	*/

	int		jump()
	{
		if (attacking == true)
			return (1);

		is_grounded = Physics2D.OverlapCircle(feet_pos.position, check_radius, ground_mask);

		if ((is_grounded || n_jumps == 1)
			&& ((player == 'a' && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
			|| ( player == 'b' &&  Input.GetKeyDown(KeyCode.UpArrow))))
		{
			rb.velocity = Vector2.up * jump_force;
			max_jump_timer = max_jump_cooldown;
			n_jumps++;
			if (n_jumps == 2)
				jump_force = second_jump_force;
		}


		if (n_jumps == 2 && ((player == 'a' && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) )) || (player == 'b' && Input.GetKeyUp(KeyCode.UpArrow))))
			n_jumps = 3;

			
		if (((player == 'a' && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))) || (player == 'b' && Input.GetKey(KeyCode.UpArrow))) && n_jumps < 3)
		{
			if (max_jump_timer > 0)
			{
				rb.velocity = Vector2.up * jump_force;
				max_jump_timer -= Time.deltaTime;
			}
		}
		else if (is_grounded == true)
		{
			n_jumps = 0;
			jump_force = og_jump_force;
		}

		return (0);
	}










	/*
	**	ft_attack
	*/

	void ft_attack()
	{
		if (attacking == true && attack_key == true)
		{
			attack_key = false;
			attack_time_max = Time.time + attack_cooldown;
		}
		if (attack_time_max < Time.time)
		{
			attack_key = true;
			attacking = false;
		}
	}










	/*
	**		Getting hit
	*/

	public bool		is_attacking_combo;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (	((this.tag == "A" && other.tag == "B") || (this.tag == "B" && other.tag == "A")))
		{
			ultimate_now++;
			if (ultimate_now == ultimate_max)
			{
				ultimate_now = 0;
				opponent.ultimate_hitted = true;
			}
			opponent.one_shield_less();	
			opponent.pushback();
		}
	}

	void one_life_less()
	{
		lives--;
		shields = shields_max;
		text_life.text = lives.ToString();
		text_shield.text = shields.ToString();

	}

	void one_shield_less()
	{
		if (shields != 1)
			shields--;
		text_shield.text = shields.ToString();
	}








	/*
	**		Knockback
	*/

	void pushback()
	{
		knockback_bool = true;

		if (ultimate_hitted == true)
		{
			rb.AddForce(new Vector2(
								force_depending_shield() * ft_direction() * 2,
								force_depending_shield() * 0.5f * 2),
								ForceMode2D.Impulse);
			ultimate_hitted = false;
		}
		else
		{
			rb.AddForce(new Vector2(
								force_depending_shield() * ft_direction(),
								force_depending_shield() * 0.5f),
								ForceMode2D.Impulse);
		}
		StartCoroutine(knockback_pause());
	}

	private IEnumerator knockback_pause()
	{
		yield return new WaitForSeconds(knockback_time);
		knockback_bool = false;
	}

	int	ft_direction()
	{
		float diff_x;

		diff_x = opponent.tr.position.x - tr.position.x;
		if (diff_x < 0)
			return (1);
		return (-1);
	}








	/*
	**	KnockBack Increment
	*/

	float[] arr_knockback = new float[]
	{
		6,			//	1
		5,			//	2
		5,			//	3
		5,			//	4
		4,			//	5

		4,			//	6
		4,			//	7
		4,			//	8
		4,			//	9
		3,			//	10

		3,			//	12
		3,			//	13
		3,			//	14
		3,			//	15



		2,			//	16
		2,			//	17
		1,			//	18
		1,			//	19
		1,			//	20
	};



	float force_depending_shield()
	{
		print("(" + ( shields - 1 )+ ")");
		print("arr_knockback _ : " + arr_knockback[shields - 1]  + " | Total strenght: " +   (Knockback_strenght * arr_knockback[shields - 1]));
		return Knockback_strenght * arr_knockback[shields - 1];
	}








	/*
	**		Death
	*/

	public void death()
	{
		one_life_less();
		StartCoroutine(death_wait());
	}

	private IEnumerator death_wait()
	{
		tr.position = new Vector3(-10000, -10000, 0);
		yield return new WaitForSeconds(2);

		rb.velocity = new Vector2(0, 0);
		if (player == 'a')
			tr.position = new Vector3(-7.069f, 1, 0);
		else 
			tr.position = new Vector3(4.732f, 1, 0);
	}
}
