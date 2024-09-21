
//internal void
// render_background()
//{
//	unsigned int* pixel = (u32*)render_state.memory;
//	for (int y = 0; y < render_state.height; y++)
//	{
//		for (int x = 0; x < render_state.width; x++)
//		{
//			//if (x / 640)
//			//{
//			//	*pixel++ = 0x00EE00 ;      // GREEN				
//			//}
//			//else 
//			//{					
//			//	*pixel++ = 0xff4500;   // Orange
//			//}
//
//			// minus two color equal same
//			//if (x % render_state.width < render_state.width / 2)
//			//{
//			//	*pixel++ = 0x00EE00;  // GREEN
//
//			//}
//			//else
//			//{
//			//	*pixel++ = 0xff4500;  // Orange
//			//}
//			*pixel++ = 0x00EE00 * x + 0xff4500 * y;
//		}
//	}
//}

internal void 
 clear_screen(ui32 color) 
{
	ui32* pixel = (ui32*)render_state.memory;
	for (int y = 0; y < render_state.height; y++)
	{
		for (int x = 0; x < render_state.width; x++)
		{
			*pixel++ = color;
		}
	}

}//////////////////////////////////////////////////////////////////////////////////////////////


internal void 
draw_rect_in_pixel(int x0, int y0, int x1, int y1, ui32 color)
{	
	x0 = clamp(0, x0, render_state.width);
	x1 = clamp(0, x1, render_state.width);
	y0 = clamp(0, y0, render_state.height);
	y1 = clamp(0, y1, render_state.height);

	for (int y = y0; y < y1; y++)
	{
		ui32* pixel = (ui32*) render_state.memory + x0 + y * render_state.width; // đã hiểu ui32 có chức năng là gì nhưng tại sao lại thêm con trỏ???
		
		for (int x = x0; x < x1; x++)
		{
			*pixel++ = color;
		}
	}
}//////////////////////////////////////////////////////////////////////////////////////////////

g_varible float render_scale = 0.01f;

internal void
draw_arena_borders(float arena_x, float arena_y, ui32 color)
{
	arena_x *= render_state.height * render_scale;
	arena_y *= render_state.height * render_scale;

	int x0 = (int)((float)render_state.width * .5f - arena_x);
	int x1 = (int)((float)render_state.width * .5f + arena_x);
	int y0 = (int)((float)render_state.height * .5f - arena_y);
	int y1 = (int)((float)render_state.height * .5f + arena_y);

	draw_rect_in_pixel(0, 0, render_state.width, y0, color);
	draw_rect_in_pixel(0, y1,x1, render_state.height, color);
	draw_rect_in_pixel(0, y0, x0, y0, color);
	draw_rect_in_pixel(x1, y0, render_state.height,render_state.height, color);
}

// draw_rect
internal void
draw_rect(float x, float y, float half_size_x, float half_size_y, ui32 color)
{
	x *= render_state.height * render_scale;
	y *= render_state.height * render_scale;
	half_size_x *= render_state.height * render_scale;
	half_size_y *= render_state.height * render_scale;

	x += render_state.width / 2.f;
	y += render_state.height / 2.f;

	// change to pixel
	int x0 = x - half_size_x;
	int x1 = x + half_size_x;
	int y0 = y - half_size_y;
	int y1 = y + half_size_y;

	draw_rect_in_pixel(x0, y0, x1, y1, color);
}//////////////////////////////////////////////////////////////////////////////////////////////


// draw_text
const char* letters[][7] = {
	" 00",
	"0  0",
	"0  0",
	"0000",
	"0  0",
	"0  0",
	"0  0",

	"000",
	"0  0",
	"0  0",
	"000",
	"0  0",
	"0  0",
	"000",

	" 000",
	"0",
	"0",
	"0",
	"0",
	"0",
	" 000",

	"000",
	"0  0",
	"0  0",
	"0  0",
	"0  0",
	"0  0",
	"000",

	"0000",
	"0",
	"0",
	"000",
	"0",
	"0",
	"0000",

	"0000",
	"0",
	"0",
	"000",
	"0",
	"0",
	"0",

	" 000",
	"0",
	"0",
	"0 00",
	"0  0",
	"0  0",
	" 000",

	"0  0",
	"0  0",
	"0  0",
	"0000",
	"0  0",
	"0  0",
	"0  0",

	"000",
	" 0",
	" 0",
	" 0",
	" 0",
	" 0",
	"000",

	" 000",
	"   0",
	"   0",
	"   0",
	"0  0",
	"0  0",
	" 000",

	"0  0",
	"0  0",
	"0 0",
	"00",
	"0 0",
	"0  0",
	"0  0",

	"0",
	"0",
	"0",
	"0",
	"0",
	"0",
	"0000",

	"00 00",
	"0 0 0",
	"0 0 0",
	"0   0",
	"0   0",
	"0   0",
	"0   0",

	"00  0",
	"0 0 0",
	"0 0 0",
	"0 0 0",
	"0 0 0",
	"0 0 0",
	"0  00",

	"0000",
	"0  0",
	"0  0",
	"0  0",
	"0  0",
	"0  0",
	"0000",

	" 000",
	"0  0",
	"0  0",
	"000",
	"0",
	"0",
	"0",

	" 000 ",
	"0   0",
	"0   0",
	"0   0",
	"0 0 0",
	"0  0 ",
	" 00 0",

	"000",
	"0  0",
	"0  0",
	"000",
	"0  0",
	"0  0",
	"0  0",

	" 000",
	"0",
	"0 ",
	" 00",
	"   0",
	"   0",
	"000 ",

	"000",
	" 0",
	" 0",
	" 0",
	" 0",
	" 0",
	" 0",

	"0  0",
	"0  0",
	"0  0",
	"0  0",
	"0  0",
	"0  0",
	" 00",

	"0   0",
	"0   0",
	"0   0",
	"0   0",
	"0   0",
	" 0 0",
	"  0",

	"0   0 ",
	"0   0",
	"0   0",
	"0 0 0",
	"0 0 0",
	"0 0 0",
	" 0 0 ",

	"0   0",
	"0   0",
	" 0 0",
	"  0",
	" 0 0",
	"0   0",
	"0   0",

	"0   0",
	"0   0",
	" 0 0",
	"  0",
	"  0",
	"  0",
	"  0",

	"0000",
	"   0",
	"  0",
	" 0",
	"0",
	"0",
	"0000",

	"   0",
	"  0",
	"  0",
	" 0",
	" 0",
	"0",
	"0",
	
};
internal void
draw_text(const char *text, float x, float y, float size, ui32 color)
{
	float half_size = size * .5f;
	float original_y = y;

	while(*text)
	{
		if(*text != 32)
		{
			const char **a_letter;
			if (*text == 47) a_letter = letters[27];
			else a_letter = letters[*text - 'A'];
			float original_x = x;

			for (int i = 0; i < 7; i++)
			{
				const char* row = a_letter[i];

				while (*row) // *row luôn = true và sẽ chạy cho đến khi nào gặp ký tự null trong câu điều kiện if(kiển tra ký tự)
				{
					if (*row == '0')
					{
						draw_rect(x, y, half_size, half_size, color);
					}
					x += size;
					row++;
				}
				y -= size;
				x = original_x; // chạy debug để biết thêm thông tin chi tiết 
			}
		}
		text++;
		x += size * 6.f;
		y = original_y;
	}
}//////////////////////////////////////////////////////////////////////////////////////////////
/*Nếu bạn giả sử vòng lặp for đang chạy vòng đầu tiên và const char* row = a_letter[0]; , thì vòng lặp while sẽ được thực hiện theo cách sau :

1. Dòng const char* row = a_letter[0]; gán giá trị của con trỏ a_letter[0] cho con trỏ row.Điều này đồng nghĩa với việc row sẽ trỏ đến dòng đầu tiên trong mảng letters.

2. Vòng lặp while (*row) sẽ tiếp tục cho đến khi giá trị của ký tự mà row đang trỏ đến là ký tự null('\0').

3. Trong vòng lặp while, câu lệnh if (*row == '0') kiểm tra giá trị của ký tự đang được trỏ bởi row có phải là ký tự '0' hay không.Nếu đúng, hàm draw_rect sẽ được gọi để vẽ một hình chữ nhật tại vị trí(x, y) với kích thước là half_size* half_size và màu sắc là color.

4. sau đó, x được tăng lên size để di chuyển vị trí vẽ sang phải để vẽ ký tự tiếp theo trong chuỗi.

5. Con trỏ row được di chuyển lên phía sau để trỏ tới ký tự tiếp theo trong dòng.

6. Quá trình lặp lại từ bước 2 đến bước 5 cho đến khi đã duyệt qua tất cả các ký tự trong dòng đầu tiên của mảng letters.

7. Sau khi đã duyệt qua tất cả các ký tự trong dòng đầu tiên, y được giảm đi size để di chuyển xuống dòng tiếp theo để vẽ.

8. x được đặt lại thành original_x để di chuyển vị trí vẽ về lại đầu dòng ban đầu.

9. uá trình lặp lại từ bước 1 cho đến bước 8 cho đến khi đã duyệt qua tất cả các dòng trong mảng letters.*/

////////////////////////////////////////////////////////////////////////////////////////////////
//draw_number
internal void
draw_number(int number, float x, float y, float size, ui32 color)
{
	float half_size = size * .5f;

	bool drew_number = false;
	while (number || !drew_number)
	{	
		drew_number = true;
		int digit = number % 10;
		number = number / 10;

		switch (digit)
		{
			case 0:
			{
				draw_rect(x - size, y, half_size, 2.5f * size, color);
				draw_rect(x + size, y, half_size, 2.5f * size, color);
				draw_rect(x, y + size * 2.f, half_size, half_size, color);
				draw_rect(x, y - size * 2.f, half_size, half_size, color);
				x -= size * 4.f;
			}break;

			case 1:
			{
				draw_rect(x + size, y, half_size, 2.5f * size, color);
				x -= size * 2.f;
			}break;

			case 2:
			{
				draw_rect(x, y + size * 2.f, 1.5f * size, half_size, color);
				draw_rect(x, y, 1.5f * size, half_size, color);
				draw_rect(x, y - size * 2.f, 1.5f * size, half_size, color);
				draw_rect(x + size, y + size, half_size, half_size, color);
				draw_rect(x - size, y - size, half_size, half_size, color);
			}break;

			case 3:
			{
				draw_rect(x - half_size, y + size * 2.f, size, half_size, color);
				draw_rect(x - half_size, y, size, half_size, color);
				draw_rect(x - half_size, y - size * 2.f, size, half_size, color);
				draw_rect(x + size, y, half_size, 2.5f * size, color);
				x -= size * 4.f;
			}break;

			case 4:
			{
				draw_rect(x + size, y, half_size, 2.5f * size, color);
				draw_rect(x - size, y + size, half_size, 1.5f * size, color);
				draw_rect(x, y, half_size, half_size, color);
				x -= size * 4.f;
			}break;

			case 5:
			{
				draw_rect(x, y + size * 2.f, 1.5f * size, half_size, color);
				draw_rect(x, y, 1.5f * size, half_size, color);
				draw_rect(x, y - size * 2.f, 1.5f * size, half_size, color);
				draw_rect(x - size, y + size, half_size, half_size, color);
				draw_rect(x + size, y - size, half_size, half_size, color);
				x -= size * 4.f;			
			}break;
		}
	}
}///////////////////////////////////////////////////////////////////////////////////////////////

