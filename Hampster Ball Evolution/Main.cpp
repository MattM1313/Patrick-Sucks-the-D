#include "ClientAPI.h"
#include "Game.h"

int main(int argc, char* argcs[])
{
	////-- Initialize the API
	ClientAPI::Init("Hampster Ball Evolution", 800,	600);

	// Set Custom Events
	ClientAPI::SubscribeCustomUpdate(Game::Update);
	ClientAPI::SubscribeCustomDraw(Game::Draw);
	ClientAPI::SubscribeEnterKeyFunc(Game::OnEscapePressed);
	ClientAPI::SubscribeEscapeKeyFunc(Game::OnEnterPressed);

	// Call the Game Load
	Game::LoadContent();

	//-- Start the APIs main loop
	ClientAPI::BeginMainLoop();

	//-- Quit the API once the APIs Main loop is over
	ClientAPI::Quit();
	return 0;
}