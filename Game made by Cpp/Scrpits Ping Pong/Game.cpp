#define is_down(b) input->buttons[b].is_down
#define pressed(b) (input->buttons[b].is_down && input->buttons[b].changed)	
#define released(b) (!input->buttons[b].is_down && input->buttons[b].changed)


float player_p, player_dp, player_AI_p, player_AI_dp;
float arena_half_size_x = 90, arena_half_size_y = 45;
float player_half_size_x = 2.5, player_half_size_y = 12;
float ball_p_x, ball_p_y, ball_dp_x = 120, ball_dp_y, ball_half_size = 1; // ball_dp_x is speed ball
float speed = 1200; int AI_speed = 850;

int player_score, player_AI_score;

internal void 
player(float* p, float* dp, float ddp, float dt)
{
	ddp -= *dp * 10.f;
	*p = *p + *dp * dt + ddp * dt * dt * .5f;
	*dp = *dp + ddp * dt;

	//  check player move with arena game
	if (*p + player_half_size_y > arena_half_size_y)
	{
		*p = arena_half_size_y - player_half_size_y;
		*dp = 0;
	}
	else if (*p - player_half_size_y < -arena_half_size_y)
	{
		*p = -arena_half_size_y + player_half_size_y;
		*dp = 0;
	}/////////////////////////////////////////////////////////////////////////////////////////////////

}

enum Gamemode
{
	GM_MENU,
	GM_GAMEPLAY,
};
Gamemode current_gamemode;
int hot_button;
bool enemy_AI;

/////////////////////////////////////////////////////////////////////////////////////////////////////
internal bool  // check collison tabbar with ball
aabb_vs_aabb(float p1x, float p1y, float hs1x, float hs1y,
	float p2x, float p2y, float hs2x, float hs2y)
{
	return (p1x + hs1x > p2x - hs2x &&
		p1x - hs1x < p2x + hs2x &&
		p1y + hs1y > p2y - hs2y &&
		p1y + hs1y < p2y + hs2y);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
internal void simulate_game(Input* input, float d_t)
{
	//clear_screen(0xff5500); // BackGround
	draw_rect(0, 0, arena_half_size_x, arena_half_size_y, 0xffaa33);// arena play
	draw_arena_borders(arena_half_size_x, arena_half_size_y, 0xff5500);

	float player_ddp = 0.f; // units per second

	if (is_down(BUTTON_UP)) player_ddp += speed;                       //if (pressed(BUTTON_RIGHT)) player_pos_x += speed ;	
	if (is_down(BUTTON_DOWN)) player_ddp -= speed;                     //if (pressed(BUTTON_LEFT)) player_pos_x -= speed ;
	
/////////////////////////////////////////////////////////////////////////////////////////////////////
	if (current_gamemode == GM_GAMEPLAY)
	{
		float player_AI_ddp = 0.f; // units per second
		//AI_player
		if (!enemy_AI)
		{
			if (is_down(BUTTON_W)) player_AI_ddp += AI_speed;
			if (is_down(BUTTON_S)) player_AI_ddp -= AI_speed;
		}
		else
		{
			//if (ball_p_y > player_AI_p + 2.f) player_AI_ddp += AI_speed;
			//if (ball_p_y < player_AI_p - 2.f) player_AI_ddp -= AI_speed;
			player_AI_ddp = (ball_p_y - player_AI_p) * 100;
			if (player_AI_ddp > AI_speed) player_AI_ddp = AI_speed;
			if (player_AI_ddp < AI_speed) player_AI_ddp = -AI_speed;
		}
		
		player(&player_p, &player_dp, player_ddp, d_t);
		player(&player_AI_p, &player_AI_dp, player_AI_ddp, d_t);


		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			///// AI player move
			//player_AI_ddp -= player_AI_dp * 10.f;

			//player_AI_p = player_AI_p + player_AI_dp * d_t + player_AI_ddp * d_t * d_t * .5f;
			//player_AI_dp = player_AI_dp + player_AI_ddp * d_t;

			//// check player_AI move with arena game
			//if (player_AI_p + player_half_size_y > arena_half_size_y)
			//{
			//	player_AI_p = arena_half_size_y - player_half_size_y;
			//	player_AI_dp = 0;
			//}
			//else if (player_AI_p - player_half_size_y < -arena_half_size_y)
			//{
			//	player_AI_p = -arena_half_size_y + player_half_size_y;
			//	player_AI_dp = 0;
			//}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



		ball_p_x += ball_dp_x * d_t;
		ball_p_y += ball_dp_y * d_t;
		//Check collision ball with player
		if (aabb_vs_aabb(ball_p_x, ball_p_y, ball_half_size, ball_half_size, 80, player_p, player_half_size_x, player_half_size_y))
		{
			ball_p_x = 80 - player_half_size_x - ball_half_size;
			ball_dp_x *= -1;
			ball_dp_y = (ball_p_y - player_p) * 2 + player_dp * .75f;
		}///////////////////////////////////////////////////////////////////////////

		// Check collision ball with player_AI
		else if (aabb_vs_aabb(ball_p_x, ball_p_y, ball_half_size, ball_half_size, -80, player_AI_p, player_half_size_x, player_half_size_y))
		{
			ball_p_x = -80 + player_half_size_x + ball_half_size;
			ball_dp_x *= -1;
			ball_dp_y = (ball_p_y - player_AI_p) * 2 + player_AI_dp * .75f;
		}///////////////////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////////////////////////////////////////
		//check ball with arena_y
		if (ball_p_y + ball_half_size > arena_half_size_y)
		{
			ball_p_y = arena_half_size_y - ball_half_size;
			ball_dp_y *= -1;
		}
		else if (ball_p_y - ball_half_size < -arena_half_size_y)
		{
			ball_p_y = -arena_half_size_y + ball_half_size;
			ball_dp_y *= -1;
		}///////////////////////////////////////////////////////////////////////////////////////////////

		////////////////////////////////////////////////////////////////////////////////////////////////
		//infinity ball
		if (ball_p_x + ball_half_size > arena_half_size_x)
		{
			ball_dp_x *= -1;
			ball_dp_y = 0;
			ball_p_x = 0;
			ball_p_y = 0;
			player_score++;
		}
		else if (ball_p_x - ball_half_size < -arena_half_size_x)
		{
			ball_dp_x *= -1;
			ball_dp_y = 0;
			ball_p_x = 0;
			ball_p_y = 0;
			player_AI_score++;
		}//////////////////////////////////////////////////////////////////////////////////////////////

		/*float at_x = -80;
		for (int i = 0; i < player_score; i++)
		{
			draw_rect(at_x, 47.f, 1.f, 1.f, 0xaaaaaa);
			at_x -= 2.5f;
		}
		at_x = 80;
		for (int i = 0; i < player_AI_score; i++)
		{
			draw_rect(at_x, 47.f, 1.f, 1.f, 0xaaaaaa);
			at_x += 2.5f;
		}*/

		draw_number(player_score, -10, 40, 1.f, 0xbbffbb);
		draw_number(player_AI_score, 10, 40, 1.f, 0xbbffbb);

		////////////////////////////////////////////////////////////////////////////////////////////////
		draw_rect(ball_p_x, ball_p_y, ball_half_size, ball_half_size, 0x00ff22); // ball

		draw_rect(80, player_p, player_half_size_x, player_half_size_y, 0xff0000); // right bar

		draw_rect(-80, player_AI_p, player_half_size_x, player_half_size_y, 0xff0000);	// left bar
	}
	else 
	{
		if (pressed(BUTTON_LEFT) || pressed(BUTTON_RIGHT))
		{
			hot_button = !hot_button;
		}

		if (pressed(BUTTON_ENTER))
		{
			current_gamemode = GM_GAMEPLAY;
			enemy_AI = hot_button ? 0 : 1;
		}
		if (hot_button == 0)
		{
			draw_text("SINGLE PLAYER", -80, -10, 1, 0xff0000);
			draw_text("MULTI LAYER", 20, -10, 1, 0xaaaaaa);
		} 
		else
		{
			draw_text("MULTI LAYER", -80, -10, 1, 0xaaaaaa);
			draw_text("SINGLE PLAYER", 20, -10, 1, 0xff0000);
		}
		draw_text("PONG TUTORIAL", -73, 40, 2, 0xffffff);
		
	}
	
}