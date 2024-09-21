#include"Untils.cpp"
#include<Windows.h>

 
g_varible bool running = true;

struct Render_State
{
	int height, width;
	void* memory;

	BITMAPINFO bitmap_info;
};

g_varible Render_State render_state;

#include"Platform_common.cpp"
#include"Render.cpp"
#include"Game.cpp"

LRESULT CALLBACK Window_CallBack(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{	
	LRESULT result = NULL;
	switch (msg)
	{
	case WM_CLOSE:
	case WM_DESTROY:
		//PostQuitMessage(0);
		return running = false ;
		break;

	case WM_SIZE:
	{
		RECT rect;
		GetClientRect(hwnd, &rect);
		render_state.width = rect.right - rect.left;
		render_state.height = rect.bottom - rect.top;

		int buffer_size = render_state.width * render_state.height * sizeof(unsigned int);

		if (render_state.memory) VirtualFree(render_state.memory, NULL, MEM_RELEASE);
								//VirtualFree(render_state.memory, NULL, MEM_RELEASE)
		render_state.memory = VirtualAlloc(NULL, buffer_size, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
							//VirtualAlloc(NULL, buffer_size, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
		render_state.bitmap_info.bmiHeader.biSize = sizeof(render_state.bitmap_info.bmiHeader);
		render_state.bitmap_info.bmiHeader.biWidth = render_state.width;
		render_state.bitmap_info.bmiHeader.biHeight = render_state.height;
		render_state.bitmap_info.bmiHeader.biPlanes = 1;
		render_state.bitmap_info.bmiHeader.biBitCount = 32;
		render_state.bitmap_info.bmiHeader.biCompression = BI_RGB;		
	}	
	break;
	default:
		result = DefWindowProc(hwnd, msg, wParam, lParam);
	}
	return result;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	ShowCursor(FALSE);

	WNDCLASS wc = { };	
	HWND hwnd = NULL;
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.hInstance = hInstance;
	wc.lpszClassName = L"Class";
	wc.lpfnWndProc = Window_CallBack;
	
	//	Check RegisterClass
	if (!RegisterClass(&wc))
	{
		MessageBox(NULL, L"Create FAILD!", L"ERROR!", NULL);
		return 0;
	}

	// CreateWindowEx
	hwnd = CreateWindowEx(0, wc.lpszClassName, L"Pong Game", WS_OVERLAPPEDWINDOW | WS_VISIBLE, CW_USEDEFAULT, CW_USEDEFAULT, 1280, 720, NULL, NULL, hInstance, NULL);
	{
		//Full Screen
		SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_OVERLAPPEDWINDOW);
		MONITORINFO mi = { sizeof(mi) };
		GetMonitorInfo(MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST), &mi);
		SetWindowPos(hwnd, HWND_TOP, mi.rcMonitor.left, mi.rcMonitor.top, mi.rcMonitor.right - mi.rcMonitor.left, mi.rcMonitor.bottom - mi.rcMonitor.top, SWP_NOOWNERZORDER | SWP_FRAMECHANGED);
	}

	// Check p_HWND
	if (!hwnd)
	{
		MessageBox(NULL, L"Create FAILD!", L"ERROR!", NULL);
		return 0;

	}

	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	HDC hdc = GetDC(hwnd);

	Input input = {};

	float delta_time = 0.016666f;
	LARGE_INTEGER frame_begin_time;
	 QueryPerformanceCounter(&frame_begin_time);
	 float performance_frequency;
	 {
		 LARGE_INTEGER perf;
		 QueryPerformanceFrequency(&perf);
		 performance_frequency = (float)perf.QuadPart;
	 }

	 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Game Loop
	while (running)
	{
		MSG msg;

		for (int i = 0; i < BUTTON_COUNT; i++)
		{
			input.buttons[i].changed = false;
		}
		while (PeekMessage(&msg, hwnd, 0, 0, PM_REMOVE))
		{
			switch (msg.message)
			{
			case WM_KEYUP: // search WM_KEYU, dealine 4/5

			case WM_KEYDOWN: // search WM_KEYDOWN, dealine 4/5
			{
			ui32 vk_code = (ui32)msg.wParam;// wParma chứ thông tin về chuột, KeyBorad,thanh cuộn (Scroll Message), (Window Message) WM_CLOSE, WM_COMMAND, WM_TIMER.
			bool is_down = ((msg.lParam & (1 << 31)) == 0); // check xem bit thứ 31 là 0 hay một nếu người chơi bấm nút thì bit 31 là 0 is_down true và ngược lại
				//lParam thường chứa các thông tin như tọa độ chuột, thông tin về trạng thái nhấn giữ phím
				// cả hai wParam và wParam đều có kiểu số nguyên 8byte 64 bit nhưng wParam phải ép kiểu về 32 bit cho nhẹ bộ nhớ

#define process_button(b, vk)\
	case vk: {\
	input.buttons[b].changed = is_down != input.buttons[b].is_down;\
	input.buttons[b].is_down = is_down;\
} break;
		//hai dòng input trên có tác dụng gì 

					switch (vk_code)
					{
						process_button(BUTTON_UP, VK_UP);
						process_button(BUTTON_DOWN, VK_DOWN);
						process_button(BUTTON_W, 'W');
						process_button(BUTTON_S, 'S');
						process_button(BUTTON_LEFT, VK_LEFT);
						process_button(BUTTON_RIGHT, VK_RIGHT);
						process_button(BUTTON_ENTER, VK_RETURN);
					}
			}break;
			default:
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
			}			
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//Simulate	
		//render_background();
		simulate_game(&input,delta_time);
		
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//Render
		StretchDIBits(hdc, 0, 0, render_state.width, render_state.height, 0, 0, render_state.width, render_state.height, render_state.memory, &render_state.bitmap_info, DIB_RGB_COLORS, SRCCOPY);


		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		LARGE_INTEGER frame_end_time;
		QueryPerformanceCounter(&frame_end_time);
		delta_time = (float)(frame_end_time.QuadPart - frame_begin_time.QuadPart) / performance_frequency;
		frame_begin_time = frame_end_time;
		
	}						
}

