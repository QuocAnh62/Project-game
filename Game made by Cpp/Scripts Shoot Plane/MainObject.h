#ifndef Main_Object_H_
#define Main_Object_H_

#include"Common_Function.h"
#include"BaseObject.h"
#include"BulletObject.h"
#include<vector>

#define WIGHT_MAIN_OBJECT 77
#define HEIGHT_MAIN_OBJECT 52

class MainObject : public BaseObject {
public:
	MainObject();
	~MainObject();

	void HandleInputAction(SDL_Event events, Mix_Chunk* bullet_sound[2]);
	void HandleMove();
	void RemoveBullet(const int& idx);
	void SetBulletObject(std::vector<BulletObject*> bullet_list) {
		p_bullet_list_ = bullet_list;
	}
	std::vector<BulletObject*> GetBulletList() const { return p_bullet_list_; }
	void MakeBullet(SDL_Surface* des);
private:
	int x_val_;
	int y_val_;

	std::vector<BulletObject*> p_bullet_list_;
};

#endif
