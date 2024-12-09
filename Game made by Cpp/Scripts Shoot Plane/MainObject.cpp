#include"MainObject.h"

MainObject::MainObject() {
	rect_.x = 0;
	rect_.y = 0;
	rect_.w = WIGHT_MAIN_OBJECT;
	rect_.h = HEIGHT_MAIN_OBJECT;
	x_val_ = 0;
	y_val_ = 0;
}
MainObject::~MainObject() {
	
}


void MainObject::HandleInputAction(SDL_Event events, Mix_Chunk *bullet_sound[2]) {
	if (events.type == SDL_KEYDOWN) {
		switch (events.key.keysym.sym)
		{
		case SDLK_w: y_val_ -= HEIGHT_MAIN_OBJECT / 12;
			break;
		case SDLK_s: y_val_ += HEIGHT_MAIN_OBJECT / 12;
			break;
		case SDLK_d: x_val_ += WIGHT_MAIN_OBJECT / 16;
			break;
		case SDLK_a: x_val_ -= WIGHT_MAIN_OBJECT / 16;
			break;
		
		default:
			break;
		}
	}


	else if (events.type == SDL_KEYUP) {
		switch (events.key.keysym.sym) {
		case SDLK_w: y_val_ += HEIGHT_MAIN_OBJECT / 12;
			break;
		case SDLK_s: y_val_ -= HEIGHT_MAIN_OBJECT / 12;
			break;
		case SDLK_d: x_val_ -= WIGHT_MAIN_OBJECT / 16;
			break;
		case SDLK_a: x_val_ += WIGHT_MAIN_OBJECT / 16;
			break;
		default:
			break;
		}
	}



	else if (events.type == SDL_MOUSEBUTTONDOWN) {
		BulletObject* p_bullet = new BulletObject();
		if (events.button.button == SDL_BUTTON_LEFT) {
			p_bullet->SetWidthHeight(WIDTH_LASER, HEIGHT_LASER);
			p_bullet->LoadImg("laser.png");
			p_bullet->set_type(BulletObject::LASER);
			Mix_PlayChannel(-1, bullet_sound[1], 0);
		}
		else if (events.button.button == SDL_BUTTON_RIGHT) {
			p_bullet->SetWidthHeight(WIDTH_SPHERE, HEIGHT_SPHERE);
			p_bullet->LoadImg("sphere.png");
			p_bullet->set_type(BulletObject::SPHERE);
			Mix_PlayChannel(-1, bullet_sound[0], 0);
		}
		p_bullet->SetRect(this->rect_.x + this->rect_.w - 20, this->rect_.y + this->rect_.h * 0.5);
		p_bullet->set_is_move(true);
		p_bullet->set_x_val_(20);
		p_bullet_list_.push_back(p_bullet);
	}


	else if (events.type == SDL_MOUSEBUTTONUP) {

	}
	else {}
}


void MainObject::MakeBullet(SDL_Surface* des) {
	for (int i = 0; i < p_bullet_list_.size(); i++) {
		BulletObject* p_bullet = p_bullet_list_.at(i);
		if (p_bullet != NULL) {
			p_bullet->Show(des);
			p_bullet->HandleMove(SCREEN_WIDTH, SCREEN_HEIGHT);
		}
		else {
			if (p_bullet != NULL) {
				p_bullet_list_.erase(p_bullet_list_.begin() + i);
				delete p_bullet;
				p_bullet = NULL;
			}
		}
	}
}

void MainObject::HandleMove() {
	rect_.x += x_val_;
	if (rect_.x < 0 || rect_.x + WIGHT_MAIN_OBJECT > SCREEN_WIDTH) {
		rect_.x -= x_val_;
	}


	rect_.y += y_val_;
	if (rect_.y < 0 || rect_.y + HEIGHT_MAIN_OBJECT > SCREEN_HEIGHT - 150) {
		rect_.y -= y_val_;
	}	
}

void MainObject::RemoveBullet(const int& idx)
{
	for (int rb = 0; rb < p_bullet_list_.size(); rb++)
	{
		if (idx < p_bullet_list_.size()) 
		{
			BulletObject* p_bullet = p_bullet_list_.at(idx);
			p_bullet_list_.erase(p_bullet_list_.begin() + idx);

			if (p_bullet != NULL) 
			{
				delete p_bullet;
				p_bullet = NULL;
			}
		}
			
		}
}


