#include"Common_Function.h"
#include"Mainobject.h"
#include"ThreatsObject.h"
#include"ExplosionObject.h"



//function Init
bool Init()
{
    if (SDL_Init(SDL_INIT_EVERYTHING) == -1)
    {
        return false;
    }
    g_screen = SDL_SetVideoMode(SCREEN_WIDTH, SCREEN_HEIGHT, SCREEN_BPP, SDL_SWSURFACE);
    if (g_screen == NULL)
    {
        return false;
    }

    if (Mix_OpenAudio(22050, MIX_DEFAULT_FORMAT, 2, 4096) == -1)
        return false;

    //Run sound
    g_sound_bullet[0] = Mix_LoadWAV("bullet_8_bit.wav");
    g_sound_bullet[1] = Mix_LoadWAV("Gun+Silencer.wav");
    g_sound_exp_helicopter[0] = Mix_LoadWAV("Bomb+1.wav");
    g_sound_exp_helicopter[1] = Mix_LoadWAV("exp_Threats.wav");
    //g_sound_background[0] = Mix_LoadWAV("sound_background.wav");


    if (g_sound_exp_helicopter[0] == NULL || g_sound_exp_helicopter[1] == NULL || g_sound_bullet[0] == NULL ||g_sound_bullet[1] == NULL)
    {
        return false;
    }

    return true;
}




int main(int arc, char* argv[])
{
    bool run_screen = true;
    int bkgn_x = 0;


    bool is_quit = false;
    if (Init() == false)
        return 0;

    g_bkground = SDLCoFunction::LoadImage("bg4800.png");
    if (g_bkground == NULL)
    {
        return 0;
    }

    // Make Main  Object
    MainObject Helicopter_object;
    Helicopter_object.SetRect(POS_X_HELICOPTER, POS_Y_HELICOPTER);
    bool ret = Helicopter_object.LoadImg("plane_fly (2).png");
    if (!ret) {
        return 0;
    }

    // Innit Explosion main
    ExplosionObject exp_Helicopter;
    ret = exp_Helicopter.LoadImg("exp_main.png");
    exp_Helicopter.setclip();
    if (ret == false)return 0;

    


    // Make Threats
    ThreatsObject* p_threats = new ThreatsObject[NUM_THREATS];
    for (int t = 0; t < NUM_THREATS; t++) {
        ThreatsObject* p_threat = (p_threats + t);
        if (p_threat) {
            ret = p_threat->LoadImg("af1.png");
            if (ret == false) {
                return 0;
            }

            int rand_y = rand() % 400;
            if (rand_y > SCREEN_HEIGHT - 150) {
                rand_y = SCREEN_HEIGHT * 0.3;
            }

            p_threat->SetRect(SCREEN_WIDTH + t*350, rand_y);
            p_threat->set_x_val(SEEP_THREAT);

            BulletObject* p_bullet = new BulletObject();
            p_threat->InitBullet(p_bullet);            
           
        }
    }
    //// Innit Explosion threats
    ExplosionObject exp_threat ;
    ret = exp_threat.LoadImg("exp.png");
    exp_threat.setclip();
    if (ret == false)return 0;
   

    
  

    while (!is_quit)
    {
        while (SDL_PollEvent(&g_even))
        {
           // Mix_PlayChannel(-1, g_sound_background[0], 0);
            if (g_even.type == SDL_QUIT)
            {
                is_quit = true;
                break;
            }
            Helicopter_object.HandleInputAction(g_even,g_sound_bullet);
        }


        if (run_screen == true) {
            bkgn_x -= SEEP_BACKGROUND; 
            if (bkgn_x <= -(SCREEN_WIDTH_BKG - SCREEN_WIDTH)) {
                run_screen = false;
            }
            else {
                SDLCoFunction::ApplySurface(g_bkground, g_screen, bkgn_x, 0);
            }

        }
        else {
            SDLCoFunction::ApplySurface(g_bkground, g_screen, bkgn_x, 0);
        }



        //Main Object
        Helicopter_object.HandleMove();
        Helicopter_object.Show(g_screen);
        Helicopter_object.MakeBullet(g_screen);
                            
        
        //Run Threats  

        for (int tt = 0; tt < NUM_THREATS; tt++)
        {           
            ThreatsObject* p_threat = (p_threats + tt);          
            if (p_threat)
            {
                p_threat->HandleMove(SCREEN_WIDTH, SCREEN_HEIGHT);
                p_threat->Show(g_screen);
                p_threat->MakeBullet(g_screen, SCREEN_WIDTH, SCREEN_HEIGHT);
                
                bool is_col_t = false;
                std::vector<BulletObject*> bullet_arr = p_threat->GetBulletList();
                for (int blt = 0; blt < bullet_arr.size(); blt++) {
                    BulletObject* p_bullet = bullet_arr.at(blt);
                    if (p_bullet) {
                        is_col_t = SDLCoFunction::CheckCollision(p_bullet->GetRect(), Helicopter_object.GetRect());
                        if (is_col_t == true) {
                            p_threat->ResetBullet(p_bullet);
                            break;
                        }
                    }
                }


                //Up date srceen
                if (SDL_Flip(g_screen) == -1)
                    return 0;

                //Check collision main and threats
                bool is_col = SDLCoFunction::CheckCollision(Helicopter_object.GetRect(), p_threat->GetRect());
                if (is_col || is_col_t)
                {
                    for (int ex = 0; ex < 4; ex++) 
                    {
                        int x_pos = (Helicopter_object.GetRect().x + Helicopter_object.GetRect().w * 0.5) - EXPLOSION_WIDTH * 0.5;
                        int y_pos = (Helicopter_object.GetRect().y + Helicopter_object.GetRect().h * 0.5) - EXPLOSION_HEIGHT * 0.5;

                        exp_Helicopter.setframe(ex);
                        exp_Helicopter.SetRect(x_pos, y_pos);
                        exp_Helicopter.ShowEX(g_screen);
                        
                        SDL_Delay(100);
                        //Up date srceen
                        if (SDL_Flip(g_screen) == -1)
                            return 0;                                            
                    }
                    Mix_PlayChannel(-1, g_sound_exp_helicopter[0], 0);
                                      
                    if (MessageBox(NULL, L"Game Over", L"", MB_OK) == IDOK)
                    {
                        delete[] p_threats;
                        SDLCoFunction::CleanUp();
                        SDL_Quit();
                        return 1;
                    }
                }

                    std::vector<BulletObject*> bullet_list = Helicopter_object.GetBulletList();
                    for (int bl = 0; bl < bullet_list.size(); bl++)
                    {
                        BulletObject* p_bullet = bullet_list.at(bl);
                        if (p_bullet != NULL)
                        {
                            bool ret_col = SDLCoFunction::CheckCollision(p_bullet->GetRect(), p_threat->GetRect());
                            if (ret_col)
                            {
                                for (int tx = 0; tx < 4; tx++) 
                                {
                                    int x_pos = p_bullet->GetRect().x - EXPLOSION_WIDTH * 0.5;
                                    int y_pos = p_bullet->GetRect().y - EXPLOSION_HEIGHT * 0.5;

                                    exp_threat.setframe(tx);
                                    exp_threat.SetRect(x_pos, y_pos);
                                    exp_threat.ShowEX(g_screen);                                    
                                }

                            p_threat->Reset(SCREEN_WIDTH + tt * 350);                           
                            Helicopter_object.RemoveBullet(bl);
                            Mix_PlayChannel(-1, g_sound_exp_helicopter[1], 0);// init audio 
                            if (SDL_Flip(g_screen) == -1)
                               return 0;
                            }

                        }
                    }
                 
            }        
        }

        //Up date srceen
        if (SDL_Flip(g_screen) == -1)
            return 0;
    }

    delete[]p_threats;
    SDLCoFunction::CleanUp();
    SDL_Quit();
    return 1;
}