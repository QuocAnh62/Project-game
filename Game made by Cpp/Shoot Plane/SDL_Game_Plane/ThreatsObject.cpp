#include"ThreatsObject.h"

ThreatsObject::ThreatsObject() {
	rect_.x = SCREEN_WIDTH;
	rect_.y = SCREEN_HEIGHT;
	rect_.w = WIDTH_THREATS;
	rect_.h = HEIGHT_THREATS;
	x_val_ = 0;
	y_val_ = 0;
}

ThreatsObject::~ThreatsObject() {
	if (p_bullet_list_.size() > 0) 
	{
		for (int i = 0; i < p_bullet_list_.size(); i++) {
			BulletObject* p_bullet = new BulletObject();
			if (p_bullet != NULL) 
			{
				delete p_bullet;
				p_bullet = NULL;
			}
		}
		p_bullet_list_.clear();
	}
}

void ThreatsObject::InitBullet(BulletObject* p_bullet) {
	if (p_bullet) {
		bool ret = p_bullet->LoadImg("sphere2.png");
		if (ret) 
		{
			p_bullet->set_is_move(true);
			p_bullet->SetWidthHeight(WIDTH_SPHERE, HEIGHT_SPHERE);
			p_bullet->set_type(BulletObject::SPHERE);
			p_bullet->SetRect(rect_.x, rect_.y + rect_.h * 0.5);
			p_bullet->set_x_val_(8);
			p_bullet_list_.push_back(p_bullet);
		}
	}
}
void ThreatsObject::MakeBullet(SDL_Surface* des, const int& x_limit, const int& y_limit) {
	for (int i = 0; i < p_bullet_list_.size(); i++) {
		BulletObject* p_bullet = p_bullet_list_.at(i);
		if (p_bullet) {
			if (p_bullet->get_is_move()) {
				p_bullet->Show(des);
				p_bullet->HandleMoveForThreats();
				
			}
			else {
				p_bullet->set_is_move(true);
				p_bullet->SetRect(rect_.x, rect_.y+rect_.h*0.5);
			}
		}
	}



}

void ThreatsObject::HandleMove(const int& x_border, const int& y_border) {
	rect_.x -= x_val_;
	if (rect_.x == 0) {
		rect_.x = SCREEN_WIDTH;
		int rand_y = rand()%400;
		if (rand_y > SCREEN_HEIGHT - UNDER_LIMIT_THREAT ) {
			rand_y = SCREEN_HEIGHT*0.3;
		}
		rect_.y = rand_y;
	}
}

void ThreatsObject::HandleInputAction(SDL_Event events) {

}

void ThreatsObject::Reset(const int& xboder) {
	rect_.x = xboder;
	int rand_y = rand() % 400;
	if (rand_y > SCREEN_HEIGHT - UNDER_LIMIT_THREAT) {
		rand_y = SCREEN_HEIGHT * 0.3;
	}
	rect_.y = rand_y;
	for (int i = 0; i < p_bullet_list_.size(); i++) {
		BulletObject* p_bullet = p_bullet_list_.at(i);
		if (p_bullet) {
			ResetBullet(p_bullet);
		}
	}
}

void ThreatsObject::ResetBullet(BulletObject* p_bullet) 
{
	p_bullet->SetRect(rect_.x, rect_.y + rect_.h * 0.5);
}

