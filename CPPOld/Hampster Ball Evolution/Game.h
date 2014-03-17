#include "ClientAPI.h"

// Menus
#include "MainMenu.h"

class Game
{
public:
	static void LoadContent();

	static void Update(double time);
	static void Draw();

	static void OnEscapePressed();
	static void OnEnterPressed();
};