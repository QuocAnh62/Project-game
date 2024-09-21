struct Button_Stae
{
	bool is_down;
	bool changed;
};

enum
{
	BUTTON_UP,
	BUTTON_DOWN,
	BUTTON_W,
	BUTTON_S,
	BUTTON_LEFT,
	BUTTON_RIGHT,
	BUTTON_ENTER,

	BUTTON_COUNT, // Should be the last item
};

struct Input
{
	Button_Stae buttons[BUTTON_COUNT];

};