#ifndef COMMON_FUNCTION_H_
#define COMMON_FUNCTION_H_

#include<Windows.h>
#include<SDL.h>
#include<string>
#include<SDL_image.h>
#include<SDL_mixer.h>
#undef main

// BackGround
const int SCREEN_WIDTH = 1200;
const int SCREEN_HEIGHT = 600;
const int SCREEN_WIDTH_BKG = 4800;
const int SCREEN_HEIGHT_BKG = 600;
const int SCREEN_BPP = 32;
const int SEEP_BACKGROUND = 1;// seep backgournd


//Helicopter
const int POS_X_HELICOPTER = 100;
const int POS_Y_HELICOPTER = 200;

// Threats 
const int SEEP_THREAT = 2;  //speeed threats
const int NUM_THREATS = 3;

static SDL_Surface* g_screen = NULL;
static SDL_Surface* g_bkground = NULL;
static SDL_Event g_even;


//Audio
static Mix_Chunk* g_sound_bullet[2];
static Mix_Chunk* g_sound_exp_helicopter[2];
static Mix_Chunk* g_sound_background[1];


 

namespace SDLCoFunction {
	SDL_Surface* LoadImage(std::string file_path);
	void ApplySurface(SDL_Surface* src, SDL_Surface* des, int x, int y);
	void ApplySurfaceClip(SDL_Surface* src, SDL_Surface* des, SDL_Rect* clip,int x, int y);
	void CleanUp();
	bool CheckCollision(const SDL_Rect& object_1, const SDL_Rect& object_2);
}

#endif
