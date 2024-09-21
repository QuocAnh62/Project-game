#ifndef THREATS_OBJECT_H_
#define THREATS_OBJECT_H_
#include"Common_Function.h"
#include"BaseObject.h"
#include"BulletObject.h"
#include<vector>

#define WIDTH_THREATS 80
#define HEIGHT_THREATS 33

const int UNDER_LIMIT_THREAT = 150;

class ThreatsObject : public BaseObject {
public:
	ThreatsObject();
	~ThreatsObject();

	void HandleMove(const int&x_border, const int&y_border);
	void HandleInputAction(SDL_Event events);

	void set_x_val(const int& val) {
		x_val_ = val;
	}
	void set_y_val(const int& val) {
		y_val_ = val;
	}

	int get_x_val()const { return x_val_; }
	int get_y_val()const { return y_val_; }

	void SetBulletObject(std::vector<BulletObject*> bullet_list) {
		p_bullet_list_ = bullet_list;
	}
	std::vector<BulletObject*> GetBulletList() const { return p_bullet_list_; }

	void InitBullet(BulletObject* p_bullet);
	void MakeBullet(SDL_Surface* des, const int& x_limit, const int& y_limit);
	void Reset(const int& xborder);
	void ResetBullet(BulletObject* p_bullet);

private:
	int x_val_;
	int y_val_;

	std::vector<BulletObject*> p_bullet_list_;
	
};


#endif